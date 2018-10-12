import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class SaleOrderApiService {

  private url = 'http://localhost:5000/api/salesorders';

  constructor(private httpClient: HttpClient) { }

  getAllSalesOrder(): Observable<SalesOrderView[]> {
    return this.httpClient.get<SalesOrderView[]>(`${this.url}`);
  }

  getSalesOrderById(id: number): Observable<SalesOrder> {
    return this.httpClient.get<SalesOrder>(`${this.url}/${id}`);
  }

  createSalesOrder(finishedProduct: SalesOrder): Observable<SalesOrder> {
    return this.httpClient.post<SalesOrder>(`${this.url}`, finishedProduct);
  }

  updateSalesOrder(id: number, finishedProduct: SalesOrder): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.url}/${id}`, finishedProduct);
  }

  deleteSalesOrder(id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.url}/${id}`);
  }
}

export class SalesOrder {
id?: number;
clientId: number;
createdBy: number;
description: string;
title: string;
initialPayment: number;
paymentMethod: number;
orderDetail: SalesOrderDetail[] = [];


}

class SalesOrderDetail {
  itemId: number;
  unitPrice: number;
  quantity: number;
  dueDate: number;
}


export class SalesOrderView {
  Id: number;
  CustomerName: string;
  OrderCode: string;
  CreatedBy: string;
  ItemCode: string;
  Quantity: number;
  UnitPrice: number;

  remainingPayment: number;
  paidAmount: number;
  totalAmount: number;
  OrderedOn: string;
  DueDate: string;
}
