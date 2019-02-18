import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockBatchViewComponent } from './stock-batch-view/stock-batch-view.component';
import { StockBatchFormComponent } from './stock-batch-form/stock-batch-form.component';
import { LotMovementFormComponent } from './lot-movement-form/lot-movement-form.component';

const routes: Routes = [
  {
    path: '', component: StockBatchViewComponent,
    data: { title: 'Stock lots', breadCrum: 'stock lot' }
  },
  {
    path: 'new', component: StockBatchFormComponent,
    data: { title: 'Create new lot', breadCrum: 'New' }
  },
  {
    path: ':stockBatchId/update', component: StockBatchFormComponent,
    data: { title: 'Update lot', breadCrum: 'Update' }
  },
  {
    path: 'movements', component: LotMovementFormComponent,
    data: { title: 'New stock movement', breadCrum: 'New movement' }
  },
  {
    path: ':lotId/movements', component: LotMovementFormComponent,
    data: { title: 'New stock movement', breadCrum: 'New lot Movement' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockBatchRoutingModule { }
