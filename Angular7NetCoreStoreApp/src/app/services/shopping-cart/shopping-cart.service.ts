import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { AlertService } from '../helpers/alert/alert.service';

import { ShoppingCart } from 'src/app/models/shopping-cart';
import { Product } from 'src/app/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  private cartKeyLocalStorage = 'shopping-cart';
  private subject = new BehaviorSubject<boolean>(false);

  constructor(private alertService: AlertService) { }

  get checkIfCartHasItems() {
    var cart = this.getCart();
    if (cart.products.length > 0) {
      this.subject.next(true);
    } else {
      this.subject.next(false);
    }

    return this.subject.asObservable();
  }

  cleanCart() {
    localStorage.removeItem(this.cartKeyLocalStorage);
    this.subject.next(false);
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
    this.saveCartInLocalStorage(cart);

    this.alertService.sendSuccessMessage('Product successfully added to cart.');
    this.subject.next(true);
  }

  private saveCartInLocalStorage(shoppingCart: ShoppingCart) {
    localStorage.setItem(this.cartKeyLocalStorage, JSON.stringify(shoppingCart));
  }
}
