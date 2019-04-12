import { Component, OnInit } from '@angular/core';
import { ProductRestService } from '../../services/rest/product-rest.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  products: Object;

  constructor(private productRest: ProductRestService) { }

  ngOnInit() {
    this.productRest.getProducts().subscribe(data => {
      this.products = data;
    });
  }

}
