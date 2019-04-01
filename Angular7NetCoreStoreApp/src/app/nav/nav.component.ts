import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  appTitle: string = 'Angular7NetCoreStore App';

  constructor() { }

  ngOnInit() {
  }

  signOut() {
    localStorage.removeItem("jwt-token");
    alert('fgfdf');
 }

}
