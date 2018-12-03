/*
 * @CreateTime: Dec 3, 2018 11:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 11:26 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UnitOfMeasurmentRoutingModule } from './unit-of-measurment-routing.module';
import { UnitOfMeasurmentFormComponent } from './unit-of-measurment-form/unit-of-measurment-form.component';
import { UnitOfMeasurmentViewComponent } from './unit-of-measurment-view/unit-of-measurment-view.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [UnitOfMeasurmentFormComponent, UnitOfMeasurmentViewComponent],
  imports: [
    CommonModule,
    SharedModule,
    UnitOfMeasurmentRoutingModule
  ]
})
export class UnitOfMeasurmentModule { }
