/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 11:44 PM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CoreApiService, CustomErrorResponse } from '../../core/core-api.service';
import { catchError } from 'rxjs/operators';

@Injectable()
export class WorkOrderAPIService {
  private url = 'workorders';
  private productsIrl = 'products';
  private httpBody: URLSearchParams;


  constructor(private httpClient: HttpClient,
    private coreApiService: CoreApiService,
    @Inject('BASE_URL') private apiUrl: string) {
    this.httpBody = new URLSearchParams();
  }

  getWorkOrderById(id: number): Observable<OrderModel> {
    return this.httpClient.get<OrderModel>(`${this.apiUrl}/${this.url}/${id}`);
  }

  getAllProducts(): Observable<any[]> {
    return this.httpClient.get<any[]>(`${this.productsIrl}`);
  }

  getAllPendingWorkOrders(): Observable<PendingManufactureOrdersView[]> {
    return this.httpClient.get<PendingManufactureOrdersView[]>(`${this.apiUrl}/${this.url}?type=pending`);
  }

  getWorkOrderRequestById(id: number): Observable<OrderModel> {
    return this.httpClient.get<OrderModel>(`${this.apiUrl}/${this.url}?type=pending&salesOrderItemId=${id}`);
  }


  getAllWorkOrders(): Observable<WorkOrder[]> {
    return this.httpClient.get<WorkOrder[]>(`${this.apiUrl}/${this.url}`);
  }

  addWorkOrder(newWorkOrder: any): Observable<WorkOrderView | CustomErrorResponse> {

    return this.httpClient.post<WorkOrderView>(`${this.apiUrl}/${this.url}`, newWorkOrder).pipe(
      catchError((error: HttpErrorResponse) => this.coreApiService.handleHttpError(error))
    );
  }
  updateWorkOrder(id: number, updatedWorkOrder: WorkOrder): Observable<Boolean> {
    // this.httpBody = this.prepareRequestBody(updatedWorkOrder);
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.url}/${id}`, updatedWorkOrder);
  }

  deleteWorkOrder(workOrderId: number[]): Observable<Boolean> {
    workOrderId.forEach((id) => this.httpBody.append('id[]', `${id}`));
    return this.httpClient.post<Boolean>(`${this.apiUrl}/${this.url}`, this.httpBody);
  }

  deleteSingleWorkOrder(workOrderId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${workOrderId}`);
  }

  private prepareRequestBody(workOrder: WorkOrder): URLSearchParams {
    const dataModel = new URLSearchParams();
    for (const key in workOrder) {
      if (workOrder.hasOwnProperty(key)) {
        const value = workOrder[key];
        dataModel.set(key, value);
      }
    }
    return dataModel;
  }
}

export class WorkOrder {
  constructor() {
    this.id = 0;
    this.purchaseOrderItemId = 0;
  }
  id?: number;
  description: string;
  orderedBy: number;
  quantity: number;
  dueDate: Date;
  start: Date;
  itemId: number;
  purchaseOrderItemId?: number;
}


export class WorkOrderView {

  id: number;
  orderedBy: string;
  description: string;
  orderId: number;
  product: string;
  itemCount: number;
  costPerItem: number;
  dueDate: Date;
  start: Date;
  orderDate: Date;
  quantity: number;
  status: string;
}

export interface PendingManufactureOrdersView {
  salesOrderId: number;
  salesOrderItemId: number;
  customer: string;
  description: string;
  product: string;
  productName: string;
  productId: number;
  quantity: string;
  orderDate: Date;
  start: Date;
  dueDate: Date;
  orderedBy: string;
}

export class OrderModel {
  id?: number;
  customer = '';
  description = '';
  salesMan = '';
  salesManId?: number;
  orderedBy = '';
  orderedById?: number;
  product: string;
  productName = '';
  productId: number;
  quantity: number;
  start: Date;
  dueDate: Date;
  salesOrderItemId?: number;
}
