/*
 * @CreateTime: Sep 20, 2018 12:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 21, 2018 1:47 AM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import {
  GridModule
} from '@syncfusion/ej2-ng-grids';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { SharedModule } from '../../shared/shared.module';
import { CurrentStockViewComponent } from './current-stock-view/current-stock-view.component';
import { StockRoutingModule } from './current-stock-routing.module';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';
import { StockApiService } from './stock-api.service';

@NgModule({
  imports: [
    // angular
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    // application
    StockRoutingModule,
    SharedModule,
    // syncfusion
    GridModule,
    DropDownListModule,
    ButtonModule
  ],
  declarations: [
    // application
    CurrentStockViewComponent,
    LowStockViewComponent
  ],
  providers: [StockApiService]
})
export class StockModule { }
