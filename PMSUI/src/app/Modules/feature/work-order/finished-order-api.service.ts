/*
 * @CreateTime: Sep 20, 2018 12:58 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 20, 2018 12:58 AM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class FinishedOrderApiService {
  private url = `finished_products`;

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL')private apiUrl: string) { }

  getAllFinishedProducts(): Observable<FinishedProductsView[]> {
    return this.httpClient.get<FinishedProductsView[]>(`${this.apiUrl}/${this.url}`);
  }

  getFinishedProductById(id: number): Observable<FinishedProducts> {
    return this.httpClient.get<FinishedProducts>(`${this.apiUrl}/${this.url}/${id}`);
  }

  addFinishedProduct(finishedProduct: FinishedProducts[]): Observable<FinishedProductsView[]> {
    return this.httpClient.post<FinishedProductsView[]>(`${this.apiUrl}/${this.url}`, finishedProduct);
  }

  updateFinishedProducts(id: number, finishedProduct: FinishedProducts): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.url}/${id}`, finishedProduct);
  }

  deleteFinishedProduct(id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${id}`);
  }

}


export class FinishedProducts {

  id?: number;
  recievedBy: number;
  submittedBy: number;
  quantity: number;
  orderId: number;
}


export class FinishedProductsView {
  id: number;
  orderId: number;
  quantity: number;
  submittedBy: number;
  recievedBy: number;
  submitter: string;
  reciever: string;
  dateAdded: Date;
  dateUpdated: Date;
}
