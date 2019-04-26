import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ProductRestService } from '../../../services/product/product-rest.service';
import { ShoppingCartService } from '../../../services/shopping-cart/shopping-cart.service';

import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: Product;
  amountProductToChart: number = 0;
  amountProductToChartIsInvalid: boolean = false;
  errorMessage: string = '';

  constructor(
    private route: ActivatedRoute, 
    private location: Location, 
    private productRest: ProductRestService,
    private shoppingCartService: ShoppingCartService) { }

  ngOnInit() {
    var productId = this.route.snapshot.params.id;
    this.productRest.getProductById(productId).subscribe(data => {
      this.product = data as Product;
    });
  }

  backClicked() {
    this.location.back();
  }

  addProductToCart() {
    this.amountProductToChartIsInvalid = false;

    if (this.amountProductToChart <= 0) {
      this.amountProductToChartIsInvalid = true;
      this.errorMessage = "Selected quantity must be greater than zero.";
      return;
    }

    if (this.amountProductToChart > this.product.quantityOnHand) {
      this.amountProductToChartIsInvalid = true;
      this.errorMessage = "Selected quantity is greater than available quantity."
      return;
    }

    this.shoppingCartService.addProduct(this.product, this.amountProductToChart);
    this.amountProductToChart = 0;
  }
}
