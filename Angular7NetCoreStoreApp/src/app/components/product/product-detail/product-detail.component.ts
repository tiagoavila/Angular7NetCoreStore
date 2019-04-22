import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';
import { ProductRestService } from '../../../services/rest/product-rest.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: Object;

  constructor(private route: ActivatedRoute, private location: Location, private productRest: ProductRestService) { }

  ngOnInit() {
    var productId = this.route.snapshot.params.id;
    this.productRest.getProductById(productId).subscribe(data => {
      this.product = data;
    });
  }

  backClicked() {
    this.location.back();
  }

}
