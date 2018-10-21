import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CoreApiService {

  constructor() { }
  handleHttpError(error: HttpErrorResponse): Observable<CustomErrorResponse> {
    const errorData = new CustomErrorResponse();
    return  Observable.throw(errorData);
  }

}

export class CustomErrorResponse {
  errorNumber: number;
  message: string;
  friendlyMessage: string;
}

