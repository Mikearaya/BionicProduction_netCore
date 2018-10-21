import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LowStockItemsView } from './stock-data-models';
import { Observable } from 'rxjs';

@Injectable()
export class StockApiService {
private url = 'products';

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) {
    }

    getLowInventoryItems(): Observable<LowStockItemsView[]> {
      return this.httpClient.get<LowStockItemsView[]>(`${this.apiUrl}/${this.url}?type=low`);
    }
}
