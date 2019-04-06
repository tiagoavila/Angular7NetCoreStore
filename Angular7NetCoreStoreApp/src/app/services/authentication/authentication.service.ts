import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

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

    return this.loggedIn.asObservable(); 
  }

  login(userName: string, password: String){
    var loginModel = {
      UserName: userName,
      Password: password
    };

    let credentials = JSON.stringify(loginModel);
    return this.http.post("http://localhost:5000/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).pipe(map(response => {
      // login successful if there's a jwt token in the response
      if ((<any>response).token) {
        let token = (<any>response).token;
        localStorage.setItem("jwt-token", token);
      }
    }));
  }

  logout() {
    localStorage.removeItem("jwt-token");
    this.loggedIn.next(false);
  }
}