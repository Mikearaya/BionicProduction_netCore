import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-anual-sale-chart',
  templateUrl: './anual-sale-chart.component.html',
  styleUrls: ['./anual-sale-chart.component.css']
})
export class AnualSaleChartComponent implements OnInit {
  chartData: { month: string; sales: number; }[];
  primaryXAxis: { valueType: string; };
  primaryYAxis: { labelFormat: string; };
  legendSettings: { visible: boolean; };
  marker: { dataLabel: { visible: boolean; }; };
  tooltip: { enable: boolean; };

  constructor() { }

  ngOnInit() {
    this.chartData = [
      { month: 'Jan', sales: 35 }, { month: 'Feb', sales: 28 },
      { month: 'Mar', sales: 34 }, { month: 'Apr', sales: 32 },
      { month: 'May', sales: 40 }, { month: 'Jun', sales: 32 },
      { month: 'Jul', sales: 35 }, { month: 'Aug', sales: 55 },
      { month: 'Sep', sales: 38 }, { month: 'Oct', sales: 30 },
      { month: 'Nov', sales: 25 }, { month: 'Dec', sales: 32 }
    ];
    this.primaryXAxis = {
      valueType: 'Category'
    };
    this.primaryYAxis = {
      labelFormat: 'ETB {value} K'
    };
    this.marker = {
      dataLabel: {
        visible: true
      }
    };
    this.legendSettings = {
      visible: true
    };
    this.tooltip = {
      enable: true
    };
  }

}
