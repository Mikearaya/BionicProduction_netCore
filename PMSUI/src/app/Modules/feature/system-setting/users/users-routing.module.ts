import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserViewComponent } from './user-view/user-view.component';
import { UserFormComponent } from './user-form/user-form.component';

const routes: Routes = [
  { path: '', component: UserViewComponent, data: { title: 'Users', breadcrum: 'system-setting/users' } },
  { path: 'new', component: UserFormComponent, data: { title: 'Create user', breadcrum: '/system-setting/users/new' } },
  { path: ':userId/update', component: UserFormComponent, data: { title: 'Update user', breadcrum: '/system-setting/users' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
