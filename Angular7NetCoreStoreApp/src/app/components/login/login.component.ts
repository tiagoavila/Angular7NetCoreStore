import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';

import { AuthenticationService } from '../../services/authentication/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  messageForm: FormGroup;
  submitted = false;
  invalidLogin: boolean;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder, 
    private http: HttpClient, 
    private router: Router, 
    private route: ActivatedRoute,
    private authService: AuthenticationService) { }

  ngOnInit() {
    this.messageForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.authService.logout();
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit() {
    this.submitted = true;

    if (this.messageForm.invalid) {
        return;
    }

    this.authService.login(this.messageForm.controls.userName.value, this.messageForm.controls.password.value)
      .pipe(first())
      .subscribe(
          data => {
            this.invalidLogin = false;
            this.router.navigate([this.returnUrl]);
          },
          error => {
            //this.error = error;
            this.invalidLogin = true;
          });
  }
}
