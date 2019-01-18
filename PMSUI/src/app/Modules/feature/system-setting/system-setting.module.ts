import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemSettingRoutingModule } from './system-setting-routing.module';
import { SystemSettingComponent } from './system-setting.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [
    SystemSettingComponent
  ],
  imports: [
    CommonModule,
    SystemSettingRoutingModule,
    SharedModule
  ]
})
export class SystemSettingModule { }
