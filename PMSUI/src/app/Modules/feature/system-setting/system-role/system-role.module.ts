import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemRoleRoutingModule } from './system-role-routing.module';
import { SystemRoleViewComponent } from './system-role-view/system-role-view.component';
import { SystemRoleFormComponent } from './system-role-form/system-role-form.component';
import { SystemRoleApiService } from '../services/system-role-api.service';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    SystemRoleFormComponent,
    SystemRoleViewComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    SystemRoleRoutingModule
  ],
  providers: []
})
export class SystemRoleModule { }
