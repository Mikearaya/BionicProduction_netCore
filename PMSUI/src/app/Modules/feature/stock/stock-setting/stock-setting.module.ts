/*
 * @CreateTime: Jan 15, 2019 11:33 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 11:33 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StockSettingRoutingModule } from './stock-setting-routing.module';
import { StockSettingComponent } from './stock-setting.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [StockSettingComponent],
  imports: [
    CommonModule,
    StockSettingRoutingModule,
    SharedModule
  ]
})
export class StockSettingModule { }
