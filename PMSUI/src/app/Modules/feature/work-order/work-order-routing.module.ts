/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:49 AM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkOrderViewComponent } from './work-order-view/work-order-view.component';
import { WorkOrderFormComponent } from './work-order-form/work-order-form.component';

const routes: Routes = [
  { path: '', component: WorkOrderViewComponent },
  { path: 'new', component: WorkOrderFormComponent },
  { path: ':workOrderId/update', component: WorkOrderFormComponent }


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkOrderRoutingModule { }
