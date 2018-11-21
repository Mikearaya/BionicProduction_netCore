/*
 * @CreateTime: Nov 21, 2018 11:32 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 21, 2018 11:51 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit } from '@angular/core';
import { BionicChartService } from '../bionic-chart.service';
import { MonthlySalesReport } from '../Models/sales-order-report.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-anual-sale-chart',
  templateUrl: './anual-sale-chart.component.html',
  styleUrls: ['./anual-sale-chart.component.css']
})
export class AnualSaleChartComponent extends CommonProperties implements OnInit {
  chartData: { month: string; amount: number; }[];
  primaryXAxis: { valueType: string; };
  primaryYAxis: { labelFormat: string; };
  legendSettings: { visible: boolean; };
  marker: { dataLabel: { visible: boolean; }; };
  tooltip: { enable: boolean; };

  constructor(private chartDataService: BionicChartService) {
    super();
  }

  ngOnInit() {
   this.chartDataService.getYearlySalesReport().subscribe(
      (data: MonthlySalesReport[]) => this.chartData = data,
      this.handleError
    );

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
