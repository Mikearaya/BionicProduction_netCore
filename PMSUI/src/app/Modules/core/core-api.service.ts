/*
 * @CreateTime: Nov 10, 2018 11:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 11:43 PM
 * @Description: Modify Here, Please
 */
import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomErrorResponse } from './DataModels/system-data-models';

@Injectable()
export class CoreApiService {

  constructor() { }
  handleHttpError(error: HttpErrorResponse): Observable<CustomErrorResponse> {
    const errorData = new CustomErrorResponse();
    return  Observable.throw(errorData);
  }

}


