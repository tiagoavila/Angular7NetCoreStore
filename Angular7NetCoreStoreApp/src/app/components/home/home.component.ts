import { Component, OnInit } from '@angular/core';
import { WebApiRestService } from '../../services/rest/web-api-rest.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  h1Style: boolean = false;
  users: Object;

  constructor(private webApiRest: WebApiRestService) { }

  ngOnInit() {
    this.webApiRest.getUsers().subscribe(data => {
      this.users = data;
    });
  }

  getOrders() {
    this.webApiRest.getOrders().subscribe(data => {
      console.log(data);
    });
  }
}
