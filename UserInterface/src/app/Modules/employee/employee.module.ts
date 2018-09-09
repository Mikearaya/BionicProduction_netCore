import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule, MatCardModule, MatTableModule,
  MatPaginatorModule, MatSortModule, MatSelectModule, MatCheckboxModule, MatProgressSpinnerModule } from '@angular/material';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
import { EmployeeApiService } from './employee-api.service';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [
            SharedModule,
            EmployeeRoutingModule,
  ],
  declarations: [EmployeeFormComponent, EmployeeViewComponent],
  exports: [EmployeeFormComponent, EmployeeViewComponent],
  providers: [EmployeeApiService]
})
export class EmployeeModule { }
