import { NgModule } from '@angular/core';
import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
import { EmployeeApiService } from './employee-api.service';

import { CommonModule } from '@angular/common';
import {
  GridModule, SortService, PageService, FilterService, SearchService, GroupService,
  ColumnChooserService, ColumnMenuService, ForeignKeyService, RowDDService, EditService,
  ToolbarService, ExcelExportService
} from '@syncfusion/ej2-angular-grids';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  imports: [EmployeeRoutingModule,
    CommonModule,
    GridModule,
    ReactiveFormsModule,
  ],
  declarations: [EmployeeFormComponent, EmployeeViewComponent],
  providers: [EmployeeApiService,
    PageService,
    SortService,
    FilterService,
    SearchService,
    GroupService,
    ColumnChooserService,
    ColumnMenuService,
    ForeignKeyService,
    RowDDService,
    EditService,
    ToolbarService,
    ExcelExportService]
})
export class EmployeeModule { }
