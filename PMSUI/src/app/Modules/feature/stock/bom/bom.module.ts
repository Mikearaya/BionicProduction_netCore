/*
 * @CreateTime: Dec 5, 2018 10:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 10:12 AM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BOMRoutingModule } from './bom-routing.module';
import { BomApiService } from './bom-api.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BOMRoutingModule
  ],
  providers: [BomApiService]
})
export class BOMModule { }
