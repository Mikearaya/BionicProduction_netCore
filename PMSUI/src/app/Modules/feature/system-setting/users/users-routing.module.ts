/*
 * @CreateTime: Feb 3, 2019 5:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Feb 3, 2019 6:07 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserViewComponent } from './user-view/user-view.component';
import { UserFormComponent } from './user-form/user-form.component';
import { PasswordChangeFormComponent } from './password-change-form/password-change-form.component';
import { ProfileUpdateFormComponent } from './profile-update-form/profile-update-form.component';

const routes: Routes = [
  { path: '', component: UserViewComponent, data: { title: 'Users', breadcrum: 'system-setting/users' } },
  { path: 'new', component: UserFormComponent, data: { title: 'Create user', breadcrum: '/system-setting/users/new' } },
  { path: ':userId/update', component: ProfileUpdateFormComponent, data: { title: 'Update user', breadcrum: '/system-setting/users' } },
  {
    path: ':userId/password', component: PasswordChangeFormComponent,
    data: {
      title: 'Update user password',
      breadcrum: '/system-setting/users/password'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
