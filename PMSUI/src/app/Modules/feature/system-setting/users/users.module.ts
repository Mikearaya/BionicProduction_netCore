import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UserFormComponent } from './user-form/user-form.component';
import { UserViewComponent } from './user-view/user-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';
import { PasswordChangeFormComponent } from './password-change-form/password-change-form.component';

@NgModule({
  declarations: [
    UserFormComponent,
    UserViewComponent,
    PasswordChangeFormComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    UsersRoutingModule
  ]
})
export class UsersModule { }
