/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:49 AM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkOrderRoutingModule } from './work-order-routing.module';
import { WorkOrderAPIService } from './work-order-api.service';
import {
  PageService, SortService, FilterService, SearchService,
  GridModule, GroupService, ColumnChooserService, ColumnMenuService,
  ForeignKeyService, ReorderService, RowDDService, EditService,
  ToolbarService, ExcelExportService, ResizeService, PdfExportService, CommandColumnService
} from '@syncfusion/ej2-ng-grids';
import { WorkOrderFormComponent } from './work-order-form/work-order-form.component';
import { WorkOrderViewComponent } from './work-order-view/work-order-view.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    GridModule,
    ReactiveFormsModule,
    WorkOrderRoutingModule
  ],
  declarations: [WorkOrderFormComponent, WorkOrderViewComponent],
  providers: [
    WorkOrderAPIService,
    PdfExportService,
    , PageService,
    CommandColumnService,
    SortService,
    FilterService,
    SearchService,
    GridModule,
    GroupService,
    ColumnChooserService,
    ColumnMenuService,
    ForeignKeyService,
    ReorderService,
    RowDDService,
    EditService,
    ToolbarService,
    ExcelExportService,
    ResizeService
  ]
})
export class WorkOrderModule { }
