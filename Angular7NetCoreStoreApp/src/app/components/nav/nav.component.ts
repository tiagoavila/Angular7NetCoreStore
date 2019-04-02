import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  appTitle: string = 'Angular7NetCoreStore App';
  userIsLogged: boolean = false;

  constructor(private router: Router, private jwtHelper: JwtHelperService) { 
    this.router.events.subscribe((ev) => {
      if (ev instanceof NavigationEnd) { 
        this.checkIfUserIsLogged();
      }
    });
  }

  ngOnInit() {
    
  }

  signOut() {
    localStorage.removeItem("jwt-token");
    this.userIsLogged = false;
    this.router.navigate(['/login']);
  }

  checkIfUserIsLogged() {
    var token = this.jwtHelper.tokenGetter();
    if (token && !this.jwtHelper.isTokenExpired(token)){
      this.userIsLogged = true;
    }
  }

}
