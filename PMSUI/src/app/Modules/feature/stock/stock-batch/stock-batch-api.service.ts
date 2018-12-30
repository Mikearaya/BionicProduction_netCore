import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import {
  NewStockBatchModel,
  StockBatchDetailView,
  StockBatchListView,
  UpdatedStockBatchModel
} from 'src/app/Modules/core/DataModels/stock-batch.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockBatchApiService {

  private controller = 'inventory/stock-batchs';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }



  getStockBatchById(id: number): Observable<StockBatchDetailView> {
    return this.httpClient.get<StockBatchDetailView>(`${this.apiUrl}/${this.controller}/${id}`);
  }

  getAllStockBatchs(): Observable<StockBatchListView[]> {
    return this.httpClient.get<StockBatchListView[]>(`${this.apiUrl}/${this.controller}`);
  }

  createNewStockBatch(newBatch: NewStockBatchModel): Observable<StockBatchDetailView> {
    return this.httpClient.post<StockBatchDetailView>(`${this.apiUrl}/${this.controller}`, newBatch);
  }

  updateStockBatch(updatedBatch: UpdatedStockBatchModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${updatedBatch.Id}`, updatedBatch);
  }


  deleteStockBatch(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${id}`);
  }

}
