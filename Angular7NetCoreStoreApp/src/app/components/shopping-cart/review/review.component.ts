import { Component, OnInit } from '@angular/core';

import { ShoppingCartService } from '../../../services/shopping-cart/shopping-cart.service';

import { ShoppingCart } from 'src/app/models/shopping-cart';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {
  shoppingCart: ShoppingCart;
  totalCart: number = 0;

  constructor(private shoppingCartService: ShoppingCartService) { }

  ngOnInit() {
    this.shoppingCart = this.shoppingCartService.getCart();

    if (this.shoppingCart && this.shoppingCart.products.length > 0) {
      this.shoppingCart.products.forEach(product => {
        let totalByProduct = product.price * product.amountProductToCart;
        this.totalCart += totalByProduct;
      });
    }
  }

}
