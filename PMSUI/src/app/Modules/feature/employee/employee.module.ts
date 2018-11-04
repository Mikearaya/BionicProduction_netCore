import { NgModule } from '@angular/core';
import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
import { EmployeeApiService } from './employee-api.service';

import { CommonModule } from '@angular/common';
import {
  GridModule
} from '@syncfusion/ej2-angular-grids';
import { ReactiveFormsModule } from '@angular/forms';
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
    EmployeeApiService
  ]
})
export class EmployeeModule { }
