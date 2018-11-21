import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MonthlySalesReport } from './Models/sales-order-report.model';

@Injectable()
export class BionicChartService {

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) {

  }

  getYearlySalesReport(): Observable<MonthlySalesReport[]> {
    return this.httpClient.get<MonthlySalesReport[]>(`${this.apiUrl}/salesorders/reports`);
  }


}
