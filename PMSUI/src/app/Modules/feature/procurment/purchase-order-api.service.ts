import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import {
  NewPurchaseOrderModel,
  PurchaseOrderDetailView,
  PurchaseOrderListView,
  UpdatedPurchaseOrderModel
} from './purchase-order/pruchse-order-data.model';
import { Observable } from 'rxjs';
import { PurchaseRecievingModel } from './purchase-recieving/purchase-recieving-data.model';

@Injectable()
export class PurchaseOrderApiService {

  private controller = 'procurments/purchase-orders';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }


  getAllPurchaseOrders(): Observable<PurchaseOrderListView[]> {
    return this.httpClient.get<PurchaseOrderListView[]>(`${this.apiUrl}/${this.controller}`);
  }

  getPurchaseOrderById(purchaseOrderId: number): Observable<PurchaseOrderDetailView> {
    return this.httpClient.get<PurchaseOrderDetailView>(`${this.apiUrl}/${this.controller}/${purchaseOrderId}`);
  }

  getShippedPurchaseOrders(): Observable<PurchaseOrderListView[]> {
    return this.httpClient.get<PurchaseOrderListView[]>(`${this.apiUrl}/${this.controller}/shipped`);
  }
  createPurchaseOrder(purchaseOrder: NewPurchaseOrderModel): Observable<PurchaseOrderDetailView> {
    return this.httpClient.post<PurchaseOrderDetailView>(`${this.apiUrl}/${this.controller}`, purchaseOrder);
  }

  createPurchaseQuotation(purchaseOrder: NewPurchaseOrderModel): Observable<PurchaseOrderDetailView> {
    return this.httpClient.post<PurchaseOrderDetailView>(`${this.apiUrl}/${this.controller}/quotations`, purchaseOrder);
  }

  updatePurchaseOrder(purchaseOrder: UpdatedPurchaseOrderModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${purchaseOrder.Id}`, purchaseOrder);
  }


  deletePurchaseOrder(purchaseOrderId: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${purchaseOrderId}`);
  }

  addNewPurchaseRecieving(purchaseRecieving: PurchaseRecievingModel): Observable<PurchaseOrderDetailView> {
    return this.httpClient.post<PurchaseOrderDetailView>(`${this.apiUrl}/procurments/purchase-recievings`, purchaseRecieving);
  }

}
