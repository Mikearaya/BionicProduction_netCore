import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemSettingRoutingModule } from './system-setting-routing.module';
import { SystemSettingComponent } from './system-setting.component';
import { SharedModule } from '../../shared/shared.module';
import { SystemRoleApiService } from './services/system-role-api.service';

@NgModule({
  declarations: [
    SystemSettingComponent
  ],
  imports: [
    CommonModule,
    SystemSettingRoutingModule,
    SharedModule
  ],
  providers: [SystemRoleApiService]
})
export class SystemSettingModule { }
