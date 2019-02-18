import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockFormComponent } from './stock-form/stock-form.component';
import { StockViewComponent } from './stock-view/stock-view.component';

const routes: Routes = [
  {
    path: '', component: StockViewComponent,
    data: { title: 'Stock List', breadCrum: '' }
  },
  {
    path: 'new', component: StockFormComponent,
    data: { title: 'Add stock item', breadCrum: 'new' }
  },
  {
    path: ':itemId/update', component: StockFormComponent,
    data: { title: 'Update stock item', breadCrum: 'Update' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemRoutingModule { }
