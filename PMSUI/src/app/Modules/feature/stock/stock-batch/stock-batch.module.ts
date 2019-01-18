import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StockBatchRoutingModule } from './stock-batch-routing.module';
import { StockBatchViewComponent } from './stock-batch-view/stock-batch-view.component';
import { StockBatchFormComponent } from './stock-batch-form/stock-batch-form.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';
import { LotMovementFormComponent } from './lot-movement-form/lot-movement-form.component';

@NgModule({
  declarations: [
    StockBatchViewComponent,
    StockBatchFormComponent,
    LotMovementFormComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    StockBatchRoutingModule
  ],
  providers: []
})
export class StockBatchModule { }
