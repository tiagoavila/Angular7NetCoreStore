import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Customer } from 'src/app/models/customer';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { AlertService } from '../../services/helpers/alert/alert.service';

@Component({
  selector: 'app-register-customer',
  templateUrl: './register-customer.component.html',
  styleUrls: ['./register-customer.component.scss']
})
export class RegisterCustomerComponent implements OnInit {

  messageForm: FormGroup;
  submitted = false;
  returnUrl: string;

  constructor(private formBuilder: FormBuilder, private authService: AuthenticationService, private alertService: AlertService) { }

  ngOnInit() {
    this.messageForm = this.formBuilder.group({
      name: ['', Validators.required],
      surName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      street: ['', Validators.required],
      number: ['', Validators.required],
      complement: [''],
      district: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      country: ['', Validators.required],
      zipCode: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      areaCode: ['', Validators.required],
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.messageForm.invalid) {
      return;
    }    

    let customer: Customer = {
      areaCode: this.messageForm.controls.areaCode.value,
      city: this.messageForm.controls.city.value,
      complement: this.messageForm.controls.complement.value,
      country: this.messageForm.controls.country.value,
      district: this.messageForm.controls.district.value,
      email: this.messageForm.controls.email.value,
      name: this.messageForm.controls.name.value,
      number: this.messageForm.controls.number.value,
      password: this.messageForm.controls.password.value,
      phoneNumber: this.messageForm.controls.phoneNumber.value,
      state: this.messageForm.controls.state.value,
      street: this.messageForm.controls.street.value,
      surName: this.messageForm.controls.surName.value,
      zipCode: this.messageForm.controls.zipCode.value,
      birthDate: new Date(1991, 9, 7)
    }

    this.authService.register(customer)
      .pipe(first())
      .subscribe(
        data => {
          console.log("regiter ok");
          // this.invalidLogin = false;
          // this.router.navigate([this.returnUrl]);
          this.alertService.success("Customer registered with success");
        },
        error => {
          //this.error = error;
          console.log("regiter no ok");
          this.alertService.error("Error when registering customer");
        });
  }

}
