/*
 * @CreateTime: Nov 10, 2018 11:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 9:44 PM
 * @Description: Modify Here, Please
 */

import {
  AggregateService,
  ColumnChooserService,
  ColumnMenuService,
  CommandColumnService,
  DetailRowService,
  EditService,
  ExcelExportService,
  FilterService,
  ForeignKeyService,
  GroupService,
  PageService,
  PdfExportService,
  ReorderService,
  ResizeService,
  RowDDService,
  SearchService,
  SortService,
  ToolbarService
} from '@syncfusion/ej2-angular-grids';
import { CommonModule } from '@angular/common';
import { CoreApiService } from './core-api.service';
import { CustomerOrderGetterApiService } from './services/customer-order/customer-order-getter-api.service';
import { CustomerService } from './services/customers/customer.service';
import { EmployeeApiService } from './services/employees/employee-api.service';
import { NgModule } from '@angular/core';
import { ProductGetterService } from './services/product-getter.service';
import { ProductGroupApiService } from './services/items/product-group-api.service';
import { ProductsAPIService } from './services/items/products-api.service';
import { ShipmentApiService } from './services/shipment/shipment-api.service';
import { UnitOfMeasurmentApiService } from './services/unit-of-measurment/unit-of-measurment-api.service';
import { BomApiService } from './services/bom/bom-api.service';
import { WorkStationApiService } from './services/work-station/work-station-api.service';
import { StorageLocationApiService } from './services/storage-location/storage-location-api.service';
import { RoutingApiService } from './services/production-routing/routing-api.service';
import { ItemApiService } from './services/stock/stock-api.service';
import { CheckBoxSelectionService } from '@syncfusion/ej2-angular-dropdowns';




@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    RoutingApiService,

    ItemApiService,
    StorageLocationApiService,
    WorkStationApiService,
    ShipmentApiService,
    EmployeeApiService,
    ProductsAPIService,
    CustomerService,
    ToolbarService,
    PdfExportService,
    PageService,
    CommandColumnService,
    AggregateService,
    SortService,
    FilterService,
    SearchService,
    GroupService,
    ColumnChooserService,
    ColumnMenuService,
    ForeignKeyService,
    ReorderService,
    RowDDService,
    CheckBoxSelectionService,
    EditService,
    ExcelExportService,
    ResizeService,
    DetailRowService,
    ProductGetterService,
    CustomerOrderGetterApiService,
    CoreApiService,
    ProductGroupApiService,
    BomApiService,
    UnitOfMeasurmentApiService
  ],

})
export class CoreModule { }
