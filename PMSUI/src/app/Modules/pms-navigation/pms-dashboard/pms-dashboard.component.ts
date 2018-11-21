import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pms-dashboard',
  templateUrl: './pms-dashboard.component.html',
  styleUrls: ['./pms-dashboard.component.css']
})
export class PmsDashboardComponent implements OnInit {
  chartData: { month: string; sales: number; }[];
  primaryXAxis: { valueType: string; };
  primaryYAxis: { labelFormat: string; };

  constructor() { }

  ngOnInit() {

  }

}
