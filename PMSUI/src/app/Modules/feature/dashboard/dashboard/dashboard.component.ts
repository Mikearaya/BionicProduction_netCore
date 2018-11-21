import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../dashboard.service';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { SummaryStatstics } from '../Models/summary-statstics.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent extends CommonProperties implements OnInit {
  public chartData: { month: string; sales: number; }[];
  public primaryXAxis: { valueType: string; };
  public primaryYAxis: { labelFormat: string; };
  public statsticData: SummaryStatstics;

  constructor(private dashboardApi: DashboardService) {
    super();
  }

  ngOnInit() {
    this.dashboardApi.getSummaryStatsticsData().subscribe(
      (data: SummaryStatstics) => this.statsticData = data,
      this.handleError
    );
  }

}
