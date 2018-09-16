import { NgModule } from '@angular/core';
import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
import { EmployeeApiService } from './employee-api.service';


@NgModule({
  imports: [EmployeeRoutingModule,
  ],
  declarations: [EmployeeFormComponent, EmployeeViewComponent],
  providers: [EmployeeApiService]
})
export class EmployeeModule { }
