/*
 * @CreateTime: Nov 11, 2018 6:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 6:56 PM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { CustomerOrder } from '../../DataModels/customer-order-data-models';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CustomerOrderGetterApiService {
  private controller = 'salesorders';
  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient
  ) { }

  getCustomerOrder(customerOrderId: number): Observable<CustomerOrder> {
    return this.httpClient.get<CustomerOrder>(`${this.apiUrl}/salesorders/${customerOrderId}?type=raw`);
  }


}
