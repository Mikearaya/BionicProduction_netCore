import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ToolbarService, PdfExportService, PageService,
  CommandColumnService, SortService, FilterService,
  SearchService, GroupService, ColumnChooserService,
  ColumnMenuService, ForeignKeyService, ReorderService,
  RowDDService, EditService, ExcelExportService, ResizeService, DetailRowService
} from '@syncfusion/ej2-angular-grids';
import { CoreApiService } from './core-api.service';
import { ProductGetterService } from './services/product-getter.service';


@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    ToolbarService,
    PdfExportService,
    PageService,
    CommandColumnService,
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
    CoreApiService,
    {provide: 'EMPLOYEE_API_URL', useValue: 'http://localhost:5000/api/employees'}
  ],

})
export class CoreModule { }
