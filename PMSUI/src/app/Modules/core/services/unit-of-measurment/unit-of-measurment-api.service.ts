import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UnitOfMeasurmentView, UnitOfMeasure } from '../../DataModels/unit-of-measurment.mode';
import { Observable } from 'rxjs';

@Injectable()
export class UnitOfMeasurmentApiService {

  private controller = 'products/uom';

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) { }

  getAllUnitOfMeasures(): Observable<UnitOfMeasurmentView[]> {
    return this.httpClient.get<UnitOfMeasurmentView[]>(`${this.apiUrl}/${this.controller}`);
  }


  getAllUnitOfMeasureById(uomId: number): Observable<UnitOfMeasurmentView> {
    return this.httpClient.get<UnitOfMeasurmentView>(`${this.apiUrl}/${this.controller}/${uomId}`);
  }

  saveUnitOfMeasurment(uom: UnitOfMeasure): Observable<UnitOfMeasure> {
    return this.httpClient.post<UnitOfMeasure>(`${this.apiUrl}/${this.controller}`, uom);
  }

  updateUnitOfMeasurment(uom: UnitOfMeasure): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${uom.id}`, uom);
  }

  deleteUnitOfMeasurment(uomId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/${uomId}`);
  }
}
