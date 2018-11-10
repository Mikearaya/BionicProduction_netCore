/*
 * @CreateTime: Nov 1, 2018 1:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 1, 2018 1:31 AM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { CustomerOrderDetailView, SalesOrderView, SalesOrder } from './sales-data-model';
import { InvoiceSummary } from '../../core/DataModels/invoice-data-model';
import { catchError } from 'rxjs/operators';
import { CustomErrorResponse } from '../../core/DataModels/system-data-models';

@Injectable()
export class SaleOrderApiService {

  private url = 'salesorders';

  constructor(@Inject('BASE_URL') private apiUrl: string, private httpClient: HttpClient) { }

  getAllSalesOrder(): Observable<SalesOrderView[]> {
    return this.httpClient.get<SalesOrderView[]>(`${this.apiUrl}/${this.url}`);
  }

  getSalesOrderById(id: number): Observable<CustomerOrderDetailView> {
    return this.httpClient.get<CustomerOrderDetailView>(`${this.apiUrl}/${this.url}/${id}`);
  }

  getSalesOrderInvoices(id: number): Observable<InvoiceSummary[]> {
    return this.httpClient.get<InvoiceSummary[]>(`${this.apiUrl}/${this.url}/${id}/invoices?type=summary`);
  }

  createSalesOrder(finishedProduct: SalesOrder): Observable<SalesOrder> {
    return this.httpClient.post<SalesOrder>(`${this.apiUrl}/${this.url}`, finishedProduct);
  }

  updateSalesOrder(id: number, finishedProduct: SalesOrder): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.url}/${id}`, finishedProduct);
  }

  deleteSalesOrder(id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${id}`);
  }


}

