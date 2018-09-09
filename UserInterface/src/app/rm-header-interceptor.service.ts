import { Injectable } from '@angular/core';
import { HttpRequest, HttpInterceptor, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class RmHeaderInterceptorService  implements HttpInterceptor {

    intercept(request: HttpRequest<any>, next: HttpHandler ): Observable<HttpEvent<any>> {

      const modifiedRequest: HttpRequest<any> =  request.clone({
        setHeaders: {'Content-Type' : 'application/x-www-form-urlencoded' }
      });

        if (request.method === 'GET') {
          return next.handle(modifiedRequest);
        } else {
          return next.handle(modifiedRequest);
        }
    }

}
