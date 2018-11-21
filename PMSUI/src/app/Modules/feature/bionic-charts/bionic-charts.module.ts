import { AnualSaleChartComponent } from './anual-sale-chart/anual-sale-chart.component';
import { BionicChartsRoutingModule } from './bionic-charts-routing.module';
import {
  CategoryService,
  ChartModule,
  DataLabelService,
  LegendService,
  LineSeriesService,
  TooltipService,
  AreaSeriesService,
  AccumulationChartModule
} from '@syncfusion/ej2-angular-charts';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ProductionStatusChartComponent } from './production-status-chart/production-status-chart.component';
import { BionicChartService } from './bionic-chart.service';


@NgModule({
  declarations: [AnualSaleChartComponent],

    imports: [
      CommonModule,
      ChartModule,

      BionicChartsRoutingModule
    ],
    exports: [AnualSaleChartComponent,
    ],
    providers: [CategoryService,
      LegendService,
      TooltipService,
      DataLabelService,
      LineSeriesService,
      DataLabelService,
      LegendService,
      AreaSeriesService,

      BionicChartService
    ]
})
export class BionicChartsModule { }
