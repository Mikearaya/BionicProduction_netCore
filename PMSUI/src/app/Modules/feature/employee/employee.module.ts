import { NgModule } from '@angular/core';
import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { EmployeeViewComponent } from './employee-view/employee-view.component';


import { CommonModule } from '@angular/common';

import { SharedModule } from '../../shared/shared.module';


@NgModule({
  imports: [
    // application
    EmployeeRoutingModule,
    SharedModule,
    // angular
    CommonModule
  ],
  declarations: [
    // application
    EmployeeFormComponent,
    EmployeeViewComponent
  ],
  providers: [
    // application

  ]
})
export class EmployeeModule { }
