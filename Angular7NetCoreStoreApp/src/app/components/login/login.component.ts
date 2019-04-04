import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../../services/authentication/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  messageForm: FormGroup;
  submitted = false;
  success = false;
  loginSuccess = false;
  invalidLogin: boolean;
  isLoggedIn$: Observable<boolean>;

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private router: Router, private authService: AuthenticationService) { }

  ngOnInit() {
    this.messageForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.messageForm.invalid) {
        return;
    }

    this.authService.login(this.messageForm.controls.userName.value, this.messageForm.controls.password.value);
    this.isLoggedIn$ = this.authService.isLoggedIn;

    // var loginModel = {
    //   UserName: this.messageForm.controls.userName.value,
    //   Password: this.messageForm.controls.password.value
    // };

    // let credentials = JSON.stringify(loginModel);
    // this.http.post("http://localhost:5000/api/auth/login", credentials, {
    //   headers: new HttpHeaders({
    //     "Content-Type": "application/json"
    //   })
    // }).subscribe(response => {
    //   let token = (<any>response).token;
    //   localStorage.setItem("jwt-token", token);
    //   this.invalidLogin = false;
    //   this.router.navigate(["/"]);
    // }, err => {
    //   this.invalidLogin = true;
    // });
  }
}
