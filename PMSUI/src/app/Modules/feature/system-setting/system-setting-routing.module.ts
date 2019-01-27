import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SystemSettingComponent } from './system-setting.component';

const routes: Routes = [
  {
    path: '', component: SystemSettingComponent, children: [
      { path: 'employees', loadChildren: './employee/employee.module#EmployeeModule' },
      { path: 'company-profile', loadChildren: './organization-profile/organization-profile.module#OrganizationProfileModule' },
      { path: 'roles', loadChildren: './system-role/system-role.module#SystemRoleModule' },
      { path: 'users', loadChildren: './users/users.module#UsersModule' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemSettingRoutingModule { }
