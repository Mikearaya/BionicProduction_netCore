/*
 * @CreateTime: Sep 20, 2018 12:36 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 4, 2019 8:41 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { StockRoutingModule } from './stock-routing.module';
import { StockBatchApiService } from '../../core/services/stock-batch/stock-batch-api.service';
import { StockComponent } from './stock.component';

@NgModule({
  imports: [
    // angular
    CommonModule,
    // application
    StockRoutingModule,
    SharedModule,
  ],
  declarations: [
    // application
    StockComponent
  ],
  providers: [StockBatchApiService]
})
export class StockModule { }
