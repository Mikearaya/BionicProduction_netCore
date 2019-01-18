import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerOrderComponent } from './customer-order.component';

const routes: Routes = [
  {
    path: '', component: CustomerOrderComponent, children: [
      { path: 'customer-orders', loadChildren: './customer-order/customer-order.module#CustomerOrderModule' },
      { path: 'invoices', loadChildren: './sale-invoice/sale-invoice.module#SaleInvoiceModule' },
      { path: 'customers', loadChildren: './customer/customer.module#CustomerModule' },
      { path: 'customer-orders/:customerOrderId/booking', loadChildren: './order-booking/order-booking.module#OrderBookingModule' },
      { path: '', redirectTo: 'customer-orders', pathMatch: 'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesRoutingModule { }
