import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesRoutingModule } from './sales-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { SaleOrderApiService } from './customer-order/sale-order-api.service';
import { CustomerOrderComponent } from './customer-order.component';

@NgModule({
  imports: [
    CommonModule,
    SalesRoutingModule,
    SharedModule
  ],
  declarations: [CustomerOrderComponent],
  providers: [SaleOrderApiService]
})
export class SalesModule { }
