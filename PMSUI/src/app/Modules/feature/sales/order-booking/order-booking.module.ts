import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderBookingRoutingModule } from './order-booking-routing.module';
import { CustomerOrderBookingComponent } from './customer-order-booking/customer-order-booking.component';
import {
  SortService, FilterService, GroupService, EditService, ExcelExportService,
  ColumnChooserService, ColumnMenuService, DetailRowService, SearchService, PdfExportService,
  ReorderService, CommandColumnService, ToolbarService, ResizeService, GridModule
} from '@syncfusion/ej2-ng-grids';
import { SwitchModule, ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';
import { BookingApiService } from './booking-api.service';

@NgModule({
  imports: [
    CommonModule,
    OrderBookingRoutingModule,
    GridModule,
    SwitchModule,
    CommonModule,
    ReactiveFormsModule,
    DatePickerModule,
    DropDownListModule,
    ButtonModule
  ],
  declarations: [CustomerOrderBookingComponent],
  providers: [
    BookingApiService,
    SortService,
    FilterService,
    GroupService,
    EditService,
    ExcelExportService,
    ColumnChooserService,
    ColumnMenuService,
    DetailRowService,
    SearchService,
    PdfExportService,
    ReorderService,
    CommandColumnService,
    ToolbarService,
    ResizeService
  ]
})
export class OrderBookingModule { }
