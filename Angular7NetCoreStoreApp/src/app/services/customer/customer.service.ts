import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getCustomerById(customerId: string) {
    return this.http.get(environment.apiUrl + '/customer/' + customerId);
  }
}
