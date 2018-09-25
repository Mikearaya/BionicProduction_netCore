import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesRoutingModule } from './sales-routing.module';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';

@NgModule({
  imports: [
    CommonModule,
    SalesRoutingModule
  ],
  declarations: [SaleOrderFormComponent, SaleOrderViewComponent]
})
export class SalesModule { }
