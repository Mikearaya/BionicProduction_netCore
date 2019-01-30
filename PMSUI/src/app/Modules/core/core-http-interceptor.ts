import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpEventType,
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { tap, catchError, retry, debounceTime } from 'rxjs/operators';
import { CustomErrorResponse } from './DataModels/system-data-models';
import { AuthrizationService } from '../authorization/authrization.service';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Injectable()
export class CoreHttpInterceptor implements HttpInterceptor {

  constructor(private authorizationService: AuthrizationService,
    private router: Router) {

  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const modifiedRequest = req.clone({
      setHeaders: {
        'Authorization': `Bearer ${this.authorizationService.getToken()}`,
      }
    });

    return next.handle(modifiedRequest).pipe(

      tap(event => {
   
        if (event instanceof HttpErrorResponse) {

          switch (event.status) {

            case 401:
              this.router.navigate(['/error/unauthorized']);
              break;
            case 403:
              this.router.navigate(['/error/forbiden']);
              break;
            case 404:
              this.router.navigate(['/error/not-found']);
              break;
            case 500:
              this.router.navigate(['/error/server-error']);
              break;

          }

        }

      })
    );
  }

  private handleError(errorResponse: HttpErrorResponse) {
    alert('inside error handler');
    if (errorResponse.error instanceof ErrorEvent) {
      console.error('Client Side Error: ', errorResponse.error.message);
    }

    if (errorResponse instanceof HttpErrorResponse) {
      switch (errorResponse.status) {
        case 401:
          this.router.navigate(['/error/unauthorized']);
          break;
        case 403:
          this.router.navigate(['/error/forbiden']);
          break;
        case 404:
          this.router.navigate(['/error/not-found']);
          break;
        case 500:
          this.router.navigate(['/error/server-error']);
          break;

        default:
          break;
      }
    }

    const customerErrorResponse = new CustomErrorResponse();
    customerErrorResponse.errorNumber = errorResponse.status;
    customerErrorResponse.errorDetail = errorResponse.error;
    customerErrorResponse.message = errorResponse.statusText;

    return throwError(customerErrorResponse);
  }

}
