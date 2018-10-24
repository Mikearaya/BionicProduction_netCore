import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';
import { CustomerOrderDetailComponent } from './customer-order-detail/customer-order-detail.component';

const routes: Routes = [
  {path: '', component: SaleOrderViewComponent },
  {path: 'new', component: SaleOrderFormComponent },
  {path: ':customerOrderId/detail', component: CustomerOrderDetailComponent },
  {path: ':customerOrderId/booking', loadChildren: './order-booking/order-booking.module#OrderBookingModule' },
  { path: 'invoices', loadChildren: './sale-invoice/sale-invoice.module#SaleInvoiceModule' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesRoutingModule { }
