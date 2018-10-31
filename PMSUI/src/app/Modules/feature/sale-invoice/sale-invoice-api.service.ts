import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invoice } from './sales-invoice-data-model';
import { Observable } from 'rxjs';
import { CustomerOrder } from '../../core/DataModels/customer-order-data-models';
import { InvoiceDetail } from '../../core/DataModels/invoice-data-model';

@Injectable()
export class SaleInvoiceApiService {
  private url = 'invoices';

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) {

  }

  getAllInvoicesSummary(): Observable<InvoiceDetail[]> {
    return this.httpClient.get<InvoiceDetail[]>(`${this.apiUrl}/salesorders/${this.url}?type=summary`);
  }

  getInvoiceById(id: number): Observable<Invoice> {
    return this.httpClient.get<Invoice>(`${this.apiUrl}/${this.url}/${id}`);
  }

  getCustomerOrderInvoice(customerOrderId: number): Observable<Invoice> {
    return this.httpClient.get<Invoice>(`${this.apiUrl}${customerOrderId}/${this.url}`);
  }

  // TODO: Move method to a single accessable location
  getCustomerOrder(customerOrderId: number): Observable<CustomerOrder> {
    return this.httpClient.get<CustomerOrder>(`${this.apiUrl}/salesorders/${customerOrderId}?type=raw`);
  }

  getCustomerInvoices(customerId: number): Observable<Invoice[]> {
    return this.httpClient.get<Invoice[]>(`${this.apiUrl}/customer/${this.url}`);
  }

  createCustomerOrderInvoice(customerOrderId: number, invoice: Invoice): Observable<Invoice> {
    return this.httpClient.post<Invoice>(`${this.apiUrl}/salesorders/${customerOrderId}/${this.url}`, invoice);
  }

  updateInvoice(invoiceId: number, invoice: Invoice): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.url}/${invoiceId}`, invoice);
  }

  deleteInvoice(invoiceId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${invoiceId}`);
  }
}
