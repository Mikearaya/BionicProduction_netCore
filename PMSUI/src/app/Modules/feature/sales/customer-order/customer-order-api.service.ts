/*
 * @CreateTime: Nov 1, 2018 1:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 17, 2018 9:43 PM
 * @Description: Modify Here, Please
 */

import {
  CustomerOrderDetailView,
  CustomerOrderListView,
  NewCustomerOrderModel
} from 'src/app/Modules/core/DataModels/customer-order-data-models';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { InvoiceSummary } from '../../../core/DataModels/invoice-data-model';
import { Observable } from 'rxjs';
import { ShipmentSummary } from '../../../core/DataModels/shipment-data.model';


@Injectable()
export class CustomerOrderApiService {

  private url = 'crm/customer-orders';

  constructor(@Inject('BASE_URL') private apiUrl: string, private httpClient: HttpClient) { }

  getAllCustomerOrders(): Observable<CustomerOrderListView[]> {
    return this.httpClient.get<CustomerOrderListView[]>(`${this.apiUrl}/${this.url}`);
  }

  getCustomerOrderById(id: number): Observable<CustomerOrderDetailView> {
    return this.httpClient.get<CustomerOrderDetailView>(`${this.apiUrl}/${this.url}/${id}`);
  }

  getCustomerOrderShipmentsSummary(customerOrderId: number): Observable<ShipmentSummary[]> {
    return this.httpClient.get<ShipmentSummary[]>(`${this.apiUrl}/shipments/${this.url}/${customerOrderId}?type=summary`);
  }

  getSalesOrderInvoices(id: number): Observable<InvoiceSummary[]> {
    return this.httpClient.get<InvoiceSummary[]>(`${this.apiUrl}/${this.url}/${id}/invoices?type=summary`);
  }

  createSalesOrder(customerOrder: NewCustomerOrderModel): Observable<CustomerOrderDetailView> {
    return this.httpClient.post<CustomerOrderDetailView>(`${this.apiUrl}/${this.url}`, customerOrder);
  }

  updateSalesOrder(id: number, finishedProduct: NewCustomerOrderModel): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.url}/${id}`, finishedProduct);
  }

  deleteSalesOrder(id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${id}`);
  }

  updateCustomerOrderStatus(customerOrderId: number, newStatus: string): Observable<boolean> {
    return this.httpClient.put<boolean>(`${this.apiUrl}/${this.url}/${customerOrderId}`, { status: newStatus });
  }


}

