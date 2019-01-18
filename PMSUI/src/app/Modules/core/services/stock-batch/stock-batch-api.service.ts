import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import {
  NewStockBatchModel,
  StockBatchDetailView,
  StockBatchListView,
  UpdatedStockBatchModel,
  StockLotMovementModel,
  StockBatchStorageView
} from 'src/app/Modules/core/DataModels/stock-batch.model';
import { Observable } from 'rxjs';

@Injectable()
export class StockBatchApiService {

  private controller = 'inventory/stock-lots';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }



  getStockBatchById(id: number): Observable<StockBatchDetailView> {
    return this.httpClient.get<StockBatchDetailView>(`${this.apiUrl}/${this.controller}/${id}`);
  }

  getItemStockBatchById(itemId: number): Observable<StockBatchListView[]> {
    return this.httpClient.get<StockBatchListView[]>(`${this.apiUrl}/${this.controller}/items/${itemId}`);
  }

  getAllStockBatchs(): Observable<StockBatchListView[]> {
    return this.httpClient.get<StockBatchListView[]>(`${this.apiUrl}/${this.controller}`);
  }


  getStockLotStorages(lotId: number): Observable<StockBatchStorageView[]> {
    return this.httpClient.get<StockBatchStorageView[]>(`${this.apiUrl}/${this.controller}/${lotId}/storages`);
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

  moveStockLot(lotMovement: StockLotMovementModel): Observable<StockBatchDetailView> {
    return this.httpClient.post<StockBatchDetailView>(`${this.apiUrl}/${this.controller}/movements`, lotMovement);
  }

}
