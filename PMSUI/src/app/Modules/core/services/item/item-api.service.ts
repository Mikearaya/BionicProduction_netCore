/*
 * @CreateTime: Nov 11, 2018 12:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 12:51 AM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LowStockItemsView, ItemModel, ItemView, VendorItemViewModel } from '../../DataModels/item-data-models';
import { Observable } from 'rxjs';

@Injectable()
export class ItemApiService {
  private controller = 'products';

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) {
  }

  getLowInventoryItems(): Observable<LowStockItemsView[]> {
    return this.httpClient.get<LowStockItemsView[]>(`${this.apiUrl}/${this.controller}?type=low`);
  }

  getVendorItems(vendorId: number): Observable<VendorItemViewModel[]> {
    return this.httpClient.get<VendorItemViewModel[]>(`${this.apiUrl}/${this.controller}/vendors/${vendorId}`);
  }

  getItemById(itemId: number): Observable<ItemView> {
    return this.httpClient.get<ItemView>(`${this.apiUrl}/${this.controller}/${itemId}`);
  }

  getAllItems(): Observable<ItemView[]> {
    return this.httpClient.get<ItemView[]>(`${this.apiUrl}/${this.controller}`);
  }



  getCriticalProductById(id: number): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}/products/${id}?type=low`);
  }

  getAllCriticalProduct(id: number): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}/products/${id}`);
  }





  saveItem(item: ItemModel): Observable<ItemModel> {
    return this.httpClient.post<ItemModel>(`${this.apiUrl}/${this.controller}`, item);
  }

  updateItem(updatedItem: ItemModel): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${updatedItem.id}`, updatedItem);
  }

  deleteItemById(itemId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/${itemId}`);
  }


}
