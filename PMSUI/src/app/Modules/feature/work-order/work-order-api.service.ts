/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:49 AM
 * @Description: Modify Here, Please
 */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.prod';

@Injectable()
export class WorkOrderAPIService {
  private url = 'http://localhost:5000/api/workorders';
  private productsIrl = 'http://localhost:5000/api/products';
    private httpBody: URLSearchParams;


    constructor(private httpClient: HttpClient) {
        this.httpBody = new URLSearchParams();
    }

    getWorkOrderById(id: number): Observable<WorkOrder> {
        return this.httpClient.get<WorkOrder>(`${this.url}/${id}`);
    }

    getAllProducts(): Observable<any[]> {
        return this.httpClient.get<any[]>(`${this.productsIrl}`);
    }

    getAllPendingWorkOrders(): Observable<PendingManufactureOrdersView[]> {
      return this.httpClient.get<PendingManufactureOrdersView[]>(`${this.url}?type=pending`);
    }

    getWorkOrderRequestById(id: number): Observable<PendingManufactureOrdersView[]> {
      return this.httpClient.get<PendingManufactureOrdersView[]>(`${this.url}?type=pending&salesOrderId=${id}`);
    }


    getAllWorkOrders(): Observable<WorkOrder[]> {
        return this.httpClient.get<WorkOrder[]>(`${this.url}`);
    }

    addWorkOrder(newWorkOrder: any ): Observable<WorkOrderView> {

        return this.httpClient.post<WorkOrderView>(`${this.url}`, newWorkOrder);
    }
    updateWorkOrder(updatedWorkOrder: WorkOrder): Observable<WorkOrder> {
        this.httpBody = this.prepareRequestBody(updatedWorkOrder);
        return this.httpClient.put<WorkOrder>(`${this.url}/${updatedWorkOrder.id}`, this.httpBody.toString());
    }

    deleteWorkOrder(workOrderId: number[]): Observable<Boolean> {
        workOrderId.forEach((id) => this.httpBody.append('id[]', `${id}`));
        return this.httpClient.post<Boolean>(`${this.url}`, this.httpBody.toString());
    }

    deleteSingleWorkOrder(workOrderId: number): Observable<Boolean> {
      return this.httpClient.delete<Boolean>(`${this.url}/${workOrderId}`);
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
    this.workOrders = [];
    this.id = 0;
  }
  id?: number;
  description: string;
  orderedBy: number;
  workOrders: WorkOrderItem[];
}



export class WorkOrderItem {
  id?: number;
  quantity: number;
  dueDate: Date;
  start: Date;
  itemId: number;

}

export class WorkOrderView {

  id: number;
  orderedBy: string;
  description: string;
  orderId: number;
  product: string;
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
  quantity: string;
  orderDate: Date;
  start: Date;
  dueDate: Date;
  orderedBy: string;
}
