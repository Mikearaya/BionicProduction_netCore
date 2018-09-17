/*
 * @CreateTime: Sep 8, 2018 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2018 11:14 PM
 * @Description: Products Module Class
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsAPIService } from './products-api.service';

import { ProductsViewComponent } from './products-view/products-view.component';
import {
  PageService, SortService, FilterService, SearchService, GridModule, GroupService,
  ColumnChooserService, ColumnMenuService, ForeignKeyService, ReorderService, RowDDService,
  EditService, ToolbarService, ExcelExportService, ResizeService
} from '@syncfusion/ej2-angular-grids';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    GridModule,
    ReactiveFormsModule,
    ProductsRoutingModule,
  ],
  declarations: [ProductsViewComponent],
  providers: [ProductsAPIService,
    , PageService,
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
export class ProductsModule { }
