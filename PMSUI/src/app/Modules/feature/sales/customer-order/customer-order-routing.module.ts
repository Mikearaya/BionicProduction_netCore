import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';
import { SalesOrderDetailComponent } from './sales-order-detail/sales-order-detail.component';

const routes: Routes = [
  {
    path: '', component: SaleOrderViewComponent,
    data: { title: '', breadCrum: '' }
  },
  {
    path: 'new', component: SaleOrderFormComponent,
    data: { title: 'New customer order', breadCrum: 'New' }
  },
  {
    path: ':customerOrderId', component: SalesOrderDetailComponent,
    data: { title: 'Customer order detail', breadCrum: 'Detail' }
  },
  {
    path: ':customerOrderId/update', component: SaleOrderFormComponent,
    data: { title: 'Update customer order', breadCrum: 'Update' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerOrderRoutingModule { }
