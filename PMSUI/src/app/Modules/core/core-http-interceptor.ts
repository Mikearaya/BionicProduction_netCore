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
import { tap, catchError, retry } from 'rxjs/operators';
import { CustomErrorResponse } from './core-api.service';

@Injectable()
export class CoreHttpInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(
      retry(3),
      tap(event => {
        if (event.type === HttpEventType.Response) {
          catchError(this.handleError);

        }

      })
    );
  }

  private handleError(errorResponse: HttpErrorResponse) {
    if (errorResponse.error instanceof ErrorEvent ) {
      console.error('Client Side Error: ', errorResponse.error.message);
    }
    const customerErrorResponse = new CustomErrorResponse();
    customerErrorResponse.errorNumber = errorResponse.status;
    customerErrorResponse.message = errorResponse.error;
    customerErrorResponse.friendlyMessage = errorResponse.statusText;
    return throwError(customerErrorResponse);
  }

}
