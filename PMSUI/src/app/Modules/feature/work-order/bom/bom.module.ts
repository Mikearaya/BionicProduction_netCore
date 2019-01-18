/*
 * @CreateTime: Dec 5, 2018 10:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 7, 2018 11:33 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BOMRoutingModule } from './bom-routing.module';
import { SharedModule } from 'src/app/Modules/shared/shared.module';
import { BomViewComponent } from './bom-view/bom-view.component';
import { BomFormComponent } from './bom-form/bom-form.component';

@NgModule({
  declarations: [
    BomFormComponent,
    BomViewComponent
  ],
  imports: [
    CommonModule,
    BOMRoutingModule,
    SharedModule
  ],
  providers: []
})
export class BOMModule { }
