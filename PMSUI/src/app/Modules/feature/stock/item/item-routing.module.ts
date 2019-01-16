import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockFormComponent } from './stock-form/stock-form.component';
import { StockViewComponent } from './stock-view/stock-view.component';

const routes: Routes = [
  { path: '', component: StockViewComponent },
  { path: 'new', component: StockFormComponent },
  { path: ':itemId/update', component: StockFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemRoutingModule { }
