import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';
import { SalesOrderDetailComponent } from './sales-order-detail/sales-order-detail.component';

const routes: Routes = [
  {path: '', component: SaleOrderViewComponent },
  {path: 'new', component: SaleOrderFormComponent },
  {path: ':customerOrderId', component: SalesOrderDetailComponent },
  {path: ':customerOrderId/booking', loadChildren: '../order-booking/order-booking.module#OrderBookingModule' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesRoutingModule { }
