import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import {
  NewPurchaseOrderModel,
  PurchaseOrderDetailView,
  PurchaseOrderListView,
  UpdatedPurchaseOrderModel
} from './pruchse-order-data.model';
import { Observable } from 'rxjs';

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


  createPurchaseOrder(purchaseOrder: NewPurchaseOrderModel): Observable<PurchaseOrderDetailView> {
    return this.httpClient.post<PurchaseOrderDetailView>(`${this.apiUrl}/${this.controller}`, purchaseOrder);
  }

  updatePurchaseOrder(purchaseOrder: UpdatedPurchaseOrderModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${purchaseOrder.Id}`, purchaseOrder);
  }


  deletePurchaseOrder(purchaseOrderId: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${purchaseOrderId}`);
  }

}
