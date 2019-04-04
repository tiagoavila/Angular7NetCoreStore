import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private router: Router, private http: HttpClient, private jwtHelper: JwtHelperService) { }

  get isLoggedIn() {
    var token = this.jwtHelper.tokenGetter();
    if (token && !this.jwtHelper.isTokenExpired(token)){
      this.loggedIn.next(true);
    } else {
      this.loggedIn.next(false);
    }

    return this.loggedIn.asObservable(); // {2}
  }

  login(userName: string, password: String){
    var loginModel = {
      UserName: userName,
      Password: password
    };

    let credentials = JSON.stringify(loginModel);
    this.http.post("http://localhost:5000/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("jwt-token", token);
      //this.loggedIn.next(true);
      this.router.navigate(["/"]);
    }, err => {
      
    });

    // if (userName !== '' && password !== '' ) { // {3}
    //   this.loggedIn.next(true);
    //   this.router.navigate(['/']);
    // }
  }

  logout() {
    localStorage.removeItem("jwt-token");
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }
}
