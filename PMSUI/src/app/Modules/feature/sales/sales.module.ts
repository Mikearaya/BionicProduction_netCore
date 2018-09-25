import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesRoutingModule } from './sales-routing.module';
import { SaleOrderFormComponent } from './sale-order-form/sale-order-form.component';
import { SaleOrderViewComponent } from './sale-order-view/sale-order-view.component';
import { GridModule } from '@syncfusion/ej2-angular-grids';
import { SaleOrderApiService } from './sale-order-api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SalesRoutingModule,
    ReactiveFormsModule,
    GridModule,
    DatePickerModule,
    DropDownListModule,
    ButtonModule,
    SharedModule
  ],
  declarations: [SaleOrderFormComponent, SaleOrderViewComponent],
  providers: [SaleOrderApiService]
})
export class SalesModule { }
