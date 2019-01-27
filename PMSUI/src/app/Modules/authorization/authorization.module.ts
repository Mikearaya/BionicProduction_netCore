import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorizationRoutingModule } from './authorization-routing.module';
import { LogInComponent } from './log-in/log-in.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    LogInComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AuthorizationRoutingModule
  ]
})
export class AuthorizationModule { }
