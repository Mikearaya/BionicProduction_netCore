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
import {
  PageService, SortService, FilterService, SearchService, GroupService,
  ColumnChooserService, ColumnMenuService, ForeignKeyService, RowDDService,
  EditService, ToolbarService, ExcelExportService, GridModule
} from '@syncfusion/ej2-ng-grids';
import { ProductsViewComponent } from './products-view/products-view.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    ProductsRoutingModule,
    SharedModule

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
    RowDDService,
    EditService,
    ToolbarService,
    ExcelExportService]
})
export class ProductsModule { }
