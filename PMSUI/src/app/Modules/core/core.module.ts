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
/*
 * @CreateTime: Nov 10, 2018 11:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 7:40 PM
 * @Description: Modify Here, Please
 */



@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
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
    EditService,
    ExcelExportService,
    ResizeService,
    DetailRowService,
    ProductGetterService,
    CustomerOrderGetterApiService,
    CoreApiService,
    ProductGroupApiService,
    { provide: 'EMPLOYEE_API_URL', useValue: 'http://localhost:5000/api/employees' }
  ],

})
export class CoreModule { }
