import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerOrderRoutingModule } from './customer-order-routing.module';
import { CustomerOrderApiService } from './customer-order-api.service';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';
import { SalesOrderDetailComponent } from './sales-order-detail/sales-order-detail.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    SaleOrderFormComponent,
    SaleOrderViewComponent,
    SalesOrderDetailComponent,
  ],
  imports: [
    CommonModule,
    CustomerOrderRoutingModule,
    SharedModule
  ],
  providers: [CustomerOrderApiService]
})
export class CustomerOrderModule { }
