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

@Injectable()
export class CoreHttpInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(
      debounceTime(500) ,
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
    customerErrorResponse.errorDetail = errorResponse.error;
    customerErrorResponse.message = errorResponse.statusText;

    return throwError(customerErrorResponse);
  }

}
