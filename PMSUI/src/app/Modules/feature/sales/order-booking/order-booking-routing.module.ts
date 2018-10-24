import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerOrderBookingComponent } from './customer-order-booking/customer-order-booking.component';

const routes: Routes = [
  {path: '', component: CustomerOrderBookingComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderBookingRoutingModule { }
