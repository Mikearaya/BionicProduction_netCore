import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ToolbarService, PdfExportService, PageService,
  CommandColumnService, SortService, FilterService,
  SearchService, GroupService, ColumnChooserService,
  ColumnMenuService, ForeignKeyService, ReorderService,
  RowDDService, EditService, ExcelExportService, ResizeService
} from '@syncfusion/ej2-ng-grids';


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
    ResizeService
  ]
})
export class CoreModule { }
