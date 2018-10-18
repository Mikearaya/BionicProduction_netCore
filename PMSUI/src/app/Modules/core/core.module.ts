import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ToolbarService, PdfExportService, PageService,
  CommandColumnService, SortService, FilterService,
  SearchService, GroupService, ColumnChooserService,
  ColumnMenuService, ForeignKeyService, ReorderService,
  RowDDService, EditService, ExcelExportService, ResizeService, DetailRowService
} from '@syncfusion/ej2-ng-grids';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { CoreHttpInterceptor } from './core-http-interceptor';


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
    DetailRowService
  ],

})
export class CoreModule { }
