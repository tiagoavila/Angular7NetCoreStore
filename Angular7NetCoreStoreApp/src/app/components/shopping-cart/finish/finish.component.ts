import { Component, OnInit } from '@angular/core';

import { CustomerService } from '../../../services/customer/customer.service';

@Component({
  selector: 'app-finish',
  templateUrl: './finish.component.html',
  styleUrls: ['./finish.component.scss']
})
export class FinishComponent implements OnInit {

  customer: Object;

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    let customerId = localStorage.getItem("customer-id");
    this.customerService.getCustomerById(customerId).subscribe(data => {
      this.customer = data;
    });
  }

}
