import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot  } from '@angular/router';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { AuthenticationService } from '../services/authentication/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private jwtHelper: JwtHelperService, private router: Router, private authService: AuthenticationService) {
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this.authService.isLoggedIn         
      .pipe(
        take(1),                              
        map((isLoggedIn: boolean) => {         
          if (!isLoggedIn){
            this.router.navigate(['/login']);
            return false;
          }
          return true;
        })
      )
  }
}
