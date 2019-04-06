import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router  } from '@angular/router';

import { AuthenticationService } from '../../services/authentication/authentication.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  appTitle: string = 'Angular7NetCoreStore App';
  isLoggedIn$: Observable<boolean>;

  constructor(private authService: AuthenticationService, private router: Router) { 
  }

  ngOnInit() {
    this.isLoggedIn$ = this.authService.isLoggedIn;

    // var token = this.jwtHelper.tokenGetter();
    // if (token && !this.jwtHelper.isTokenExpired(token)){
    //   this.isLoggedIn$ = new BehaviorSubject<boolean>(true);
    // } else {
    //   this.isLoggedIn$ = new BehaviorSubject<boolean>(false);
    // }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}