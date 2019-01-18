import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeViewComponent } from './employee-view/employee-view.component';

const routes: Routes = [
                          { path: '',  component: EmployeeViewComponent, children : [
                            {path: 'new', component: EmployeeFormComponent },
                            {path: ':employeeId/update', component: EmployeeFormComponent }
                          ]}
                        ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
