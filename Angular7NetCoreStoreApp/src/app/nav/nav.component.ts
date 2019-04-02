import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  appTitle: string = 'Angular7NetCoreStore App';

  constructor(private router: Router) { }

  ngOnInit() {
  }

  signOut() {
    localStorage.removeItem("jwt-token");
    this.router.navigate(['/login']);
 }

}
