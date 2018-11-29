import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';
import { StockViewComponent } from './stock-view/stock-view.component';
import { StockFormComponent } from './stock-form/stock-form.component';




const routes: Routes = [
  { path: '', component: StockViewComponent },
  { path: 'low-stock', component: LowStockViewComponent },
  { path: 'item', component: StockFormComponent },
  { path: 'item/:itemId', component: StockFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockRoutingModule { }
