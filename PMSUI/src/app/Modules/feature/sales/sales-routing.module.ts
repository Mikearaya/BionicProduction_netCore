import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';

const routes: Routes = [
  {path: '', component: SaleOrderViewComponent },
  {path: 'new', component: SaleOrderFormComponent },
  {path: ':saleOrderId/update', component: SaleOrderFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesRoutingModule { }
