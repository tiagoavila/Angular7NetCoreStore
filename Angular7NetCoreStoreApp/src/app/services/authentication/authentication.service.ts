import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Customer } from 'src/app/models/customer';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(
    private http: HttpClient, 
    private jwtHelper: JwtHelperService) { }

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
    return this.http.post(environment.apiUrl + "/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).pipe(map(response => {
      // login successful if there's a jwt token in the response
      if ((<any>response).token) {
        let token = (<any>response).token;
        let customerId = (<any>response).customerId;

        localStorage.setItem("jwt-token", token);
        localStorage.setItem("customer-id", customerId);
        
        this.loggedIn.next(true);
      }
    }));
  }

  logout() {
    localStorage.removeItem("jwt-token");
    this.loggedIn.next(false);
  }

  register(customer: Customer) {
    let customerJson = JSON.stringify(customer);
    return this.http.post(environment.apiUrl + "/auth/register", customerJson, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  getCustomerId() {
    return localStorage.getItem("customer-id");
  }
}
