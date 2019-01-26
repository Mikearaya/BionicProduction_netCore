import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SystemRoleFormComponent } from './system-role-form/system-role-form.component';
import { SystemRoleViewComponent } from './system-role-view/system-role-view.component';

const routes: Routes = [
  { path: '', component: SystemRoleViewComponent },
  { path: 'new', component: SystemRoleFormComponent },
  { path: ':roleId/update', component: SystemRoleFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemRoleRoutingModule { }
