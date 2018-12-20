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
import { SharedModule } from '../../shared/shared.module';
import { StockRoutingModule } from './stock-routing.module';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';

import { StockViewComponent } from './stock-view/stock-view.component';
import { StockFormComponent } from './stock-form/stock-form.component';
import { ProductGroupFormComponent } from './product-group-form/product-group-form.component';
import { ProductGroupViewComponent } from './product-group-view/product-group-view.component';
import { ItemBomListViewComponent } from './item-bom-list-view/item-bom-list-view.component';
import { ItemRoutingListViewComponent } from './item-routing-list-view/item-routing-list-view.component';

@NgModule({
  imports: [
    // angular
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
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
    ItemBomListViewComponent,
    ItemRoutingListViewComponent
  ],
  providers: []
})
export class StockModule { }
