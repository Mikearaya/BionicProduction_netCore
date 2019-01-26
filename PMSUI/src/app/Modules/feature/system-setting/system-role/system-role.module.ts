import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemRoleRoutingModule } from './system-role-routing.module';
import { SystemRoleViewComponent } from './system-role-view/system-role-view.component';
import { SystemRoleFormComponent } from './system-role-form/system-role-form.component';
import { SystemRoleApiService } from './system-role-api.service';

@NgModule({
  declarations: [
    SystemRoleFormComponent,
    SystemRoleViewComponent
  ],
  imports: [
    CommonModule,
    SystemRoleRoutingModule
  ],
  providers: [SystemRoleApiService]
})
export class SystemRoleModule { }
