import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductRestService {

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get(environment.apiUrl + '/product');
  }

  getProductById(id) {
    return this.http.get(environment.apiUrl + '/product/' + id);
  }
}
