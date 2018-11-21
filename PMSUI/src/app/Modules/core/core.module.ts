/*
 * @CreateTime: Nov 10, 2018 11:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 10, 2018 11:44 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ToolbarService, PdfExportService, PageService,
  CommandColumnService, SortService, FilterService,
  SearchService, GroupService, ColumnChooserService,
  ColumnMenuService, ForeignKeyService, ReorderService,
  RowDDService, EditService, ExcelExportService, ResizeService, DetailRowService, AggregateService
} from '@syncfusion/ej2-angular-grids';
import { CoreApiService } from './core-api.service';
import { ProductGetterService } from './services/product-getter.service';
import { CustomerOrderGetterApiService } from './services/customer-order/customer-order-getter-api.service';
import { ShipmentApiService } from './services/shipment/shipment-api.service';
import { ProductsAPIService } from './services/items/products-api.service';
import { EmployeeApiService } from './services/employees/employee-api.service';
import { CustomerService } from './services/customers/customer.service';



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
    { provide: 'EMPLOYEE_API_URL', useValue: 'http://localhost:5000/api/employees' }
  ],

})
export class CoreModule { }
