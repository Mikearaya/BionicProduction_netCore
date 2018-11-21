import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatCardComponent } from './stat-card/stat-card.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BionicChartsModule } from '../bionic-charts/bionic-charts.module';

@NgModule({
  declarations: [StatCardComponent, DashboardComponent],
  exports: [StatCardComponent, DashboardComponent],
  imports: [
    CommonModule,
    BionicChartsModule,
  ],


})
export class DashboardModule { }
