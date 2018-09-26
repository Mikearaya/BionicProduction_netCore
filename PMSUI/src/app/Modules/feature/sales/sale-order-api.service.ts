import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class SaleOrderApiService {

  private url = 'http://localhost:5000/api/salesorder';

  constructor(private httpClient: HttpClient) { }

  getAllSalesOrder(): Observable<SalesOrderView[]> {
    return this.httpClient.get<SalesOrderView[]>(`${this.url}`);
  }

  getFinishedProductById(id: number): Observable<SalesOrder> {
    return this.httpClient.get<SalesOrder>(`${this.url}/${id}`);
  }

  addFinishedProduct(finishedProduct: SalesOrder[]): Observable<SalesOrderView[]> {
    return this.httpClient.post<SalesOrderView[]>(`${this.url}`, finishedProduct);
  }

  updateSalesOrder(id: number, finishedProduct: SalesOrder): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.url}/${id}`, finishedProduct);
  }

  deleteFinishedProduct(id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.url}/${id}`);
  }
}

export class SalesOrder {
id?: number;
clientId: number;


}


export class SalesOrderView {

}
