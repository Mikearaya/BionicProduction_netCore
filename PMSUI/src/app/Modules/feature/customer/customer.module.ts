
import { NgModule } from '@angular/core';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerService } from './customer.service';
import { CustomerViewComponent } from './customer-view/customer-view.component';

import { HttpClientModule } from '@angular/common/http';
import {
  GridModule, PageService, SortService, FilterService, SearchService, GroupService,
  ColumnChooserService, ColumnMenuService, ForeignKeyService, RowDDService, EditService,
  ToolbarService, ExcelExportService
} from '@syncfusion/ej2-angular-grids';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CustomerRoutingModule,
    CommonModule,
    GridModule,
    ReactiveFormsModule],
  declarations: [CustomerFormComponent, CustomerViewComponent],
  exports: [],
  providers: [CustomerService, PageService,
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
export class CustomerModule { }
