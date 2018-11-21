/*
 * @CreateTime: Nov 22, 2018 12:22 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 22, 2018 12:22 AM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SummaryStatstics } from './Models/summary-statstics.model';


@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) {

  }

  getSummaryStatsticsData(): Observable<SummaryStatstics> {
    return this.httpClient.get<SummaryStatstics>(`${this.apiUrl}/analisis`);
  }

}
