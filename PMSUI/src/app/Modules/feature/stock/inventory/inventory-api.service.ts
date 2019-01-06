import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { InventoryViewModel } from './inventory-data.model';
import { Observable } from 'rxjs';

@Injectable()
export class InventoryApiService {
  private controller = 'inventory/stock-batchs/inventory';
  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }


  getInventoryList(): Observable<InventoryViewModel[]> {
    return this.httpClient.get<InventoryViewModel[]>(`${this.apiUrl}/${this.controller}`);
  }
}
