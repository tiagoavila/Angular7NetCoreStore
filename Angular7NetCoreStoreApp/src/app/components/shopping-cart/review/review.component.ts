import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

import { ShoppingCartService } from '../../../services/shopping-cart/shopping-cart.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';

import { ShoppingCart } from 'src/app/models/shopping-cart';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {
  shoppingCart: ShoppingCart;
  isLoggedIn$: Observable<boolean>;

  constructor(
    private shoppingCartService: ShoppingCartService,
    private authService: AuthenticationService, 
    private router: Router) { }

  ngOnInit() {
    this.shoppingCart = this.shoppingCartService.getCart();
  }

  goToNextPage() {
    let isLoggedIn = false;
    this.authService.isLoggedIn.subscribe(data => {
      isLoggedIn = data;
    });

    if (isLoggedIn) {
      this.router.navigate(['/shoppingcart/finish']);
    } else{
      this.router.navigate(['/shoppingcart/identification']);
    }
  }

}
