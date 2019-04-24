import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router  } from '@angular/router';

import { AuthenticationService } from '../services/authentication/authentication.service';
import { AlertService } from '../services/helpers/alert/alert.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService, private router: Router, private alertService: AlertService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(httpErrorResponse => {
            if (httpErrorResponse.status === 401) {
                // auto logout if 401 response returned from api
                this.authenticationService.logout();

                if (this.router.url != '/login') {
                    location.reload(true);
                }
            }

            const error = httpErrorResponse.error.message || httpErrorResponse.message || httpErrorResponse.statusText;
            this.alertService.error(error);
            return throwError(error);
        }))
    }
}