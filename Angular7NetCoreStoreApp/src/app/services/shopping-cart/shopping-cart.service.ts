import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import { AlertService } from '../helpers/alert/alert.service';
import { AuthenticationService } from '../authentication/authentication.service';

import { ShoppingCart } from 'src/app/models/shopping-cart';
import { Product } from 'src/app/models/product';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  private cartKeyLocalStorage = 'shopping-cart';
  private subjectCartHasItems = new BehaviorSubject<boolean>(false);

  constructor(
    private alertService: AlertService,
    private authenticationService: AuthenticationService,
    private http: HttpClient) { }

  get checkIfCartHasItems() {
    var cart = this.getCart();
    if (cart.products.length > 0) {
      this.subjectCartHasItems.next(true);
    } else {
      this.subjectCartHasItems.next(false);
    }

    return this.subjectCartHasItems.asObservable();
  }

  cleanCart() {
    localStorage.removeItem(this.cartKeyLocalStorage);
    this.subjectCartHasItems.next(false);
  }

  getCart(): ShoppingCart {
    var cartFromLocalStorage = localStorage.getItem(this.cartKeyLocalStorage);
    var cart = JSON.parse(cartFromLocalStorage) as ShoppingCart;

    if (cart === null) {
      cart = new ShoppingCart();
    }

    return cart;
  }

  addProduct(product: Product, amountProducts: number) {
    product.amountProductToCart = amountProducts;

    var cart = this.getCart();
    cart.products.push(product);
    cart.totalCart = this.calculateTotalCart(cart);
    this.saveCartInLocalStorage(cart);

    this.alertService.sendSuccessMessage('Product successfully added to cart.');
    this.subjectCartHasItems.next(true);
  }

  placeOrder() {
    let shoppingCart = this.getCart();
    shoppingCart.customerId = this.authenticationService.getCustomerId();

    return this.http.post(environment.apiUrl + "/order", shoppingCart)
      .pipe(map(response => {
        if ((<any>response).success === true) {
          this.cleanCart();
        }
      }));
  }

  private saveCartInLocalStorage(shoppingCart: ShoppingCart) {
    localStorage.setItem(this.cartKeyLocalStorage, JSON.stringify(shoppingCart));
  }

  private calculateTotalCart(shoppingCart: ShoppingCart) {
    let totalCart = 0;
    shoppingCart.products.forEach(product => {
      let totalByProduct = product.price * product.amountProductToCart;
      totalCart += totalByProduct;
    });

    return totalCart;
  }
}
