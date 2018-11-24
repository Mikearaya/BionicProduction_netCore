/*
 * @CreateTime: Nov 24, 2018 10:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 24, 2018 10:02 PM
 * @Description: Modify Here, Please
 */
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
  AccumulationChartModule,
  AccumulationLegendService,
  AccumulationTooltipService,
  AccumulationDataLabelService,
  AccumulationAnnotationService,
  PieSeriesService,
  PyramidSeriesService
} from '@syncfusion/ej2-angular-charts';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BionicChartService } from './bionic-chart.service';
import { PieChartComponent } from './pie-chart/pie-chart.component';
import { SharedModule } from '../../shared/shared.module';
import { DonutChartComponent } from './donut-chart/donut-chart.component';
import { PyramidChartComponent } from './pyramid-chart/pyramid-chart.component';


@NgModule({
  declarations: [AnualSaleChartComponent, PieChartComponent,
    DonutChartComponent, PyramidChartComponent],

  imports: [
    CommonModule,
    ChartModule,
    AccumulationChartModule,
    SharedModule,

    BionicChartsRoutingModule
  ],
  exports: [AnualSaleChartComponent, PieChartComponent, PyramidChartComponent, DonutChartComponent
  ],
  providers: [CategoryService,
    LegendService,
    TooltipService,
    DataLabelService,
    LineSeriesService,
    PyramidSeriesService,
    DataLabelService,
    LegendService,
    AreaSeriesService,
    PieSeriesService,
    AccumulationLegendService,
    AccumulationTooltipService,
    AccumulationDataLabelService,
    AccumulationAnnotationService,

    BionicChartService
  ]
})
export class BionicChartsModule { }
