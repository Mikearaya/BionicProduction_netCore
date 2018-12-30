import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockBatchViewComponent } from './stock-batch-view/stock-batch-view.component';
import { StockBatchFormComponent } from './stock-batch-form/stock-batch-form.component';

const routes: Routes = [
  { path: '', component: StockBatchViewComponent },
  { path: 'new', component: StockBatchFormComponent },
  { path: ':stockbatchId/update', component: StockBatchFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockBatchRoutingModule { }
