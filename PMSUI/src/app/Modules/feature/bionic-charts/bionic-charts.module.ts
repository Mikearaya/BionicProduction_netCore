import { AnualSaleChartComponent } from './anual-sale-chart/anual-sale-chart.component';
import { BionicChartsRoutingModule } from './bionic-charts-routing.module';
import {
  CategoryService,
  ChartModule,
  DataLabelService,
  LegendService,
  LineSeriesService,
  TooltipService,
  AreaSeriesService
} from '@syncfusion/ej2-angular-charts';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';


@NgModule({
  declarations: [AnualSaleChartComponent],
  imports: [
    CommonModule,
    ChartModule,
    BionicChartsRoutingModule
  ],
  exports: [AnualSaleChartComponent],
  providers: [CategoryService,
    LegendService,
    TooltipService,
    DataLabelService,
    LineSeriesService,
    DataLabelService,
    LegendService,
    AreaSeriesService
    ]
})
export class BionicChartsModule { }