import {
  CriticalItemModel,
  ItemModel,
  ItemReportModel,
  ItemView,
  LowStockItemsView,
  VendorItemViewModel
} from '../../DataModels/item-data-models';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
/*
 * @CreateTime: Nov 11, 2018 12:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 7, 2019 11:01 PM
 * @Description: Modify Here, Please
 */

@Injectable()
export class ItemApiService {
  private controller = 'stocks/items';

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) {
  }

  getLowInventoryItems(): Observable<CriticalItemModel[]> {
    return this.httpClient.get<CriticalItemModel[]>(`${this.apiUrl}/${this.controller}/critical?type=purchased`);
  }

  getVendorItems(vendorId: number): Observable<VendorItemViewModel[]> {
    return this.httpClient.get<VendorItemViewModel[]>(`${this.apiUrl}/${this.controller}/vendors/${vendorId}`);
  }

  getItemById(itemId: number): Observable<ItemView> {
    return this.httpClient.get<ItemView>(`${this.apiUrl}/${this.controller}/${itemId}`);
  }

  getItemReport(): Observable<ItemReportModel[]> {
    return this.httpClient.get<ItemReportModel[]>(`${this.apiUrl}/${this.controller}/reports`);
  }


  getAllItems(): Observable<ItemView[]> {
    return this.httpClient.get<ItemView[]>(`${this.apiUrl}/${this.controller}`);
  }

  ItemCodeUnique(code: string): Observable<boolean> {
    return this.httpClient.get<boolean>(`${this.apiUrl}/${this.controller}/${code}/unique`);
  }



  getCriticalProductById(id: number): Observable<CriticalItemModel> {
    return this.httpClient.get<CriticalItemModel>(`${this.apiUrl}/${this.controller}/${id}/critical`);
  }

  getAllCriticalProduct(): Observable<CriticalItemModel[]> {
    return this.httpClient.get<CriticalItemModel[]>(`${this.apiUrl}/${this.controller}/critical?type=purchased`);
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
