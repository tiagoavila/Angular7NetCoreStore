import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';

import { CustomerService } from '../../../services/customer/customer.service';
import { ShoppingCartService } from '../../../services/shopping-cart/shopping-cart.service';
import { AlertService } from '../../../services/helpers/alert/alert.service';

import { ShoppingCart } from 'src/app/models/shopping-cart';

@Component({
  selector: 'app-finish',
  templateUrl: './finish.component.html',
  styleUrls: ['./finish.component.scss']
})
export class FinishComponent implements OnInit {

  customer: Object;
  shoppingCart: ShoppingCart;

  constructor(
    private customerService: CustomerService,
    private shoppingCartService: ShoppingCartService,
    private router: Router,
    private alertService: AlertService) { }

  ngOnInit() {
    let customerId = localStorage.getItem("customer-id");
    this.customerService.getCustomerById(customerId).subscribe(data => {
      this.customer = data;
    });

    this.shoppingCart = this.shoppingCartService.getCart();
  }

  placeOrder() {
    this.shoppingCartService.placeOrder()
      .pipe(first())
      .subscribe(
        data => {
          this.alertService.sendSuccessMessage("Order registered with success", true);
          this.router.navigate(['/']);
        },
        error => {
          this.alertService.sendErrorMessage("Error when registering order");
        });
  }

}
