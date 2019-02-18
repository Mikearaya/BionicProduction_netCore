import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerOrderComponent } from './customer-order.component';

const routes: Routes = [
  {
    path: '', component: CustomerOrderComponent, children: [
      {
        path: 'customer-orders', loadChildren: './customer-order/customer-order.module#CustomerOrderModule',
        data: { title: 'Customer orders', breadCrum: 'Customer order' }
      },
      {
        path: 'invoices', loadChildren: './sale-invoice/sale-invoice.module#SaleInvoiceModule',
        data: { title: 'Invoices', breadCrum: 'Invoices' }
      },
      {
        path: 'customers', loadChildren: './customer/customer.module#CustomerModule',
        data: { title: 'Customers', breadCrum: 'Customers' }
      },
      {
        path: 'customer-orders/:customerOrderId/booking', loadChildren: './order-booking/order-booking.module#OrderBookingModule',
        data: { title: 'Customer order Booking', breadCrum: 'Booking' }
      },
      { path: '', redirectTo: 'customer-orders', pathMatch: 'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesRoutingModule { }
