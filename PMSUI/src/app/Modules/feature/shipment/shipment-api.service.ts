import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShipmentSummaryView } from '../../core/DataModels/shipment-data.model';

@Injectable()
export class ShipmentApiService {
    private url = 'shipments';
  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) { }

    getAllShipmentSummary(): Observable<ShipmentSummaryView[]> {
      return this.httpClient.get<ShipmentSummaryView[]>(`${this.apiUrl}/${this.url}`);
    }

}
