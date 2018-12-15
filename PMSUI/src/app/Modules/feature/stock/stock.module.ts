/*
 * @CreateTime: Sep 20, 2018 12:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 10:04 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import {
  GridModule
} from '@syncfusion/ej2-angular-grids';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { SharedModule } from '../../shared/shared.module';
import { StockRoutingModule } from './stock-routing.module';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';

import { StockViewComponent } from './stock-view/stock-view.component';
import { StockFormComponent } from './stock-form/stock-form.component';
import { ItemApiService } from './stock-api.service';
import { ProductGroupFormComponent } from './product-group-form/product-group-form.component';
import { ProductGroupViewComponent } from './product-group-view/product-group-view.component';
import { ItemBomListViewComponent } from './item-bom-list-view/item-bom-list-view.component';
import { StorageLocationModule } from './storage-location/storage-location.module';

@NgModule({
  imports: [
    // angular
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    StorageLocationModule,
    // application
    StockRoutingModule,
    SharedModule,
  ],
  declarations: [
    // application
    ProductGroupFormComponent,
    ProductGroupViewComponent,
    StockFormComponent,
    StockViewComponent,
    LowStockViewComponent,
    ItemBomListViewComponent
  ],
  providers: [ItemApiService]
})
export class StockModule { }
