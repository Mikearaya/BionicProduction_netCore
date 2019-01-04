import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StockBatchRoutingModule } from './stock-batch-routing.module';
import { StockBatchViewComponent } from './stock-batch-view/stock-batch-view.component';
import { StockBatchFormComponent } from './stock-batch-form/stock-batch-form.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    StockBatchViewComponent,
    StockBatchFormComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    StockBatchRoutingModule
  ],
  providers: []
})
export class StockBatchModule { }
