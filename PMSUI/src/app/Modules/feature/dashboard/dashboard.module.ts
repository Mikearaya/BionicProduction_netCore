import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatCardComponent } from './stat-card/stat-card.component';

@NgModule({
  declarations: [StatCardComponent],
  exports: [StatCardComponent],
  imports: [
    CommonModule
  ],


})
export class DashboardModule { }
