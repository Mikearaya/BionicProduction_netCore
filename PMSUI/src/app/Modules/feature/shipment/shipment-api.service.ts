import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shipment, ShipmentSummaryView, ShipmentViewDetail } from '../../core/DataModels/shipment-data.model';

@Injectable()
export class ShipmentApiService {
  private url = 'shipments';
  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) { }

  getAllShipmentSummary(): Observable<ShipmentSummaryView[]> {
    return this.httpClient.get<ShipmentSummaryView[]>(`${this.apiUrl}/${this.url}`);
  }


  createNewShipment(newShipment: Shipment): Observable<Shipment> {
    return this.httpClient.post<Shipment>(`${this.apiUrl}/${this.url}/salesorders/${newShipment.customerOrderId}`, newShipment);
  }

  deleteShipment(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(`${this.apiUrl}/${this.url}/${id}`);
  }

  getCustomerOrderShipments(customerOrderId: number): Observable<ShipmentViewDetail[]> {
    return this.httpClient.get<ShipmentViewDetail[]>(`${this.apiUrl}/${this.url}/salesorders/${customerOrderId}`);
  }

}
