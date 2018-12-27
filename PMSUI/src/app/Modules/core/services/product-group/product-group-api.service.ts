import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductGroupView, ProductGroup } from '../../DataModels/product-group.model';
import { Observable } from 'rxjs';

@Injectable()
export class ProductGroupApiService {
  private controller = 'products/groups';
  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) { }

  getAllProductGroups(): Observable<ProductGroupView[]> {
    return this.httpClient.get<ProductGroupView[]>(`${this.apiUrl}/${this.controller}`);
  }
  getProductGroupById(groupId: number): Observable<ProductGroupView> {
    return this.httpClient.get<ProductGroupView>(`${this.apiUrl}/${this.controller}/${groupId}`);
  }

  CreateProductGroup(group: ProductGroup): Observable<ProductGroupView> {
    return this.httpClient.post<ProductGroupView>(`${this.apiUrl}/${this.controller}`, group);
  }

  UpdateProductGroup(group: ProductGroup): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${group.id}`, group);
  }

  deleteProductGroup(groupId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/${groupId}`);
  }

}
