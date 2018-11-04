import { Injectable, Inject } from '@angular/core';

import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ProductGetterService {

  constructor(private httpClient: HttpClient,
              @Inject('BASE_URL') private apiUrl: string)  { }

    getProductById(id: number): Observable<any> {
      return this.httpClient.get(`${this.apiUrl}/products/${id}`);
    }

    getCriticalProductById(id: number): Observable<any> {
      return this.httpClient.get(`${this.apiUrl}/api/products/${id}?type=low`);
    }

    getAllCriticalProduct(id: number): Observable<any> {
      return this.httpClient.get(`${this.apiUrl}/products/${id}`);
    }
}
