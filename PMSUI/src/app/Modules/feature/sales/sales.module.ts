import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesRoutingModule } from './sales-routing.module';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';
import { GridModule } from '@syncfusion/ej2-angular-grids';
import { SaleOrderApiService } from './sale-order-api.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    SalesRoutingModule,
    ReactiveFormsModule,
    GridModule
  ],
  declarations: [SaleOrderFormComponent, SaleOrderViewComponent],
  providers: [SaleOrderApiService]
})
export class SalesModule { }
