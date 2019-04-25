import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../services/authentication/authentication.service';
import { ShoppingCartService } from '../../services/shopping-cart/shopping-cart.service';

import { ShoppingCart } from 'src/app/models/shopping-cart';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  appTitle: string = 'Angular7NetCoreStore App';
  isLoggedIn$: Observable<boolean>;

  hasItemsInShoppingCart: boolean;
  shoppingCart: ShoppingCart;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private shoppingCartService: ShoppingCartService) {
  }

  ngOnInit() {
    this.isLoggedIn$ = this.authService.isLoggedIn;
    this.shoppingCartService.checkIfCartHasItems.subscribe(data => {
      this.hasItemsInShoppingCart = data;

      if (this.hasItemsInShoppingCart) {
        this.shoppingCart = this.shoppingCartService.getCart();
      }
    });
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  cleanCart(){
    this.shoppingCartService.cleanCart();
  }
}
