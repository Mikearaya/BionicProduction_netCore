import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockBatchViewComponent } from './stock-batch-view/stock-batch-view.component';
import { StockBatchFormComponent } from './stock-batch-form/stock-batch-form.component';
import { LotMovementFormComponent } from './lot-movement-form/lot-movement-form.component';

const routes: Routes = [
  { path: '', component: StockBatchViewComponent },
  { path: 'new', component: StockBatchFormComponent },
  { path: ':stockBatchId/update', component: StockBatchFormComponent },
  { path: 'movements', component: LotMovementFormComponent },
  { path: ':lotId/movements', component: LotMovementFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockBatchRoutingModule { }
