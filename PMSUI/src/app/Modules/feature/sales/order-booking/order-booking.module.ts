import { NgModule } from '@angular/core';

import { OrderBookingRoutingModule } from './order-booking-routing.module';
import { CustomerOrderBookingComponent } from './customer-order-booking/customer-order-booking.component';

import { BookingApiService } from './booking-api.service';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  imports: [
    OrderBookingRoutingModule,
    SharedModule
  ],
  declarations: [CustomerOrderBookingComponent],
  providers: [
    BookingApiService
  ]
})
export class OrderBookingModule { }
