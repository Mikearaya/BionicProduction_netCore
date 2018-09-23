/*
 * @CreateTime: Sep 20, 2018 12:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 20, 2018 12:44 AM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FinishedProductsRoutingModule } from './finished-products-routing.module';
import { FinishedProductsApiService } from './finished-products-api.service';
import { FinishedProductFormComponent } from './finished-product-form/finished-product-form.component';
import { FinishedProductsViewComponent } from './finished-products-view/finished-products-view.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import {
  GridModule, ToolbarService, PdfExportService, PageService, CommandColumnService,
  SortService, FilterService, SearchService, GroupService, ColumnChooserService,
  ColumnMenuService, ForeignKeyService, ReorderService, RowDDService, EditService,
  ExcelExportService, ResizeService
} from '@syncfusion/ej2-angular-grids';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { NumericTextBoxComponent } from '@syncfusion/ej2-angular-inputs';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    // angular
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    // application
    FinishedProductsRoutingModule,
    SharedModule,
    // syncfusion
    GridModule,
    DropDownListModule,
    ButtonModule
  ],
  declarations: [
    // application
    FinishedProductFormComponent,
    FinishedProductsViewComponent
  ],
  providers: [
    // application
    FinishedProductsApiService,

    // syncfusion
    ToolbarService,
    PdfExportService,
    PageService,
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
    ResizeService]
})
export class FinishedProductsModule { }
