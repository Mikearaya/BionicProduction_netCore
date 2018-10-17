import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpEventType,
} from '@angular/common/http';

import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { CustomErrorResponse } from './core-api.service';

@Injectable()
export class CoreHttpInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('handeld in interceptor');
    return next.handle(req).pipe(
      tap(event => {
        if (event.type === HttpEventType.Response) {
          catchError((error: HttpErrorResponse) => Observable.throw(new CustomErrorResponse()));

        }

      })
    );
  }



}
