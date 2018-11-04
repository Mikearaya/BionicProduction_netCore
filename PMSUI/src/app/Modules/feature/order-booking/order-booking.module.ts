import { NgModule } from '@angular/core';

import { OrderBookingRoutingModule } from './order-booking-routing.module';
import { CustomerOrderBookingComponent } from './customer-order-booking/customer-order-booking.component';
import {
  SortService, FilterService, GroupService, EditService, ExcelExportService,
  ColumnChooserService, ColumnMenuService, DetailRowService, SearchService, PdfExportService,
  ReorderService, CommandColumnService, ToolbarService, ResizeService, GridModule
} from '@syncfusion/ej2-angular-grids';
import { BookingApiService } from './booking-api.service';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    OrderBookingRoutingModule,
    SharedModule
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
