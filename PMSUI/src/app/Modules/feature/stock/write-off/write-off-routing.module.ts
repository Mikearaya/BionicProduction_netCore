import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WriteOffViewComponent } from './write-off-view/write-off-view.component';
import { WriteOffFormComponent } from './write-off-form/write-off-form.component';

const routes: Routes = [
  {
    path: '', component: WriteOffViewComponent
  },
  {
    path: 'new', component: WriteOffFormComponent,
    data: { title: 'Create new write off', breadcrum: 'New' }
  },
  {
    path: ':writeoffId/update', component: WriteOffFormComponent,
    data: { title: 'Update write off', breadcrum: 'Detail' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WriteOffRoutingModule { }
