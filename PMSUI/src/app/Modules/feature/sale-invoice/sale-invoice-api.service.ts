/*
 * @CreateTime: Nov 11, 2018 7:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 12:29 AM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Invoice, InvoicePaymentSummary, InvoicePayments } from './sales-invoice-data-model';
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
    return this.httpClient.get<Invoice>(`${this.apiUrl}/salesorders/${this.url}/${id}`);
  }

  getCustomerOrderInvoice(customerOrderId: number): Observable<Invoice> {
    return this.httpClient.get<Invoice>(`${this.apiUrl}${customerOrderId}/${this.url}`);
  }

  getCustomerInvoices(customerId: number): Observable<Invoice[]> {
    return this.httpClient.get<Invoice[]>(`${this.apiUrl}/customer/${this.url}`);
  }

  getInvoiceSummary(invoiceId: number): Observable<InvoicePaymentSummary> {
    return this.httpClient.get<InvoicePaymentSummary>(`${this.apiUrl}/invoices/${invoiceId}/payments`);
  }

  addInvoicePayment(payment: InvoicePayments): Observable<InvoicePayments> {
    return this.httpClient.post<InvoicePayments>(`${this.apiUrl}/invoices/${payment.id}/payments`, payment);
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
