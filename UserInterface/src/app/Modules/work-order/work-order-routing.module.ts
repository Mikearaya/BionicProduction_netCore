import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkOrderViewComponent } from './work-order-view/work-order-view.component';
import { WorkOrderFormComponent } from './work-order-form/work-order-form.component';

const routes: Routes = [
  {path: 'workorders', component : WorkOrderViewComponent},
  {path: 'new/workorders', component: WorkOrderFormComponent},
  {path: 'update/workorders/:workOrderId', component: WorkOrderFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkOrderRoutingModule { }
