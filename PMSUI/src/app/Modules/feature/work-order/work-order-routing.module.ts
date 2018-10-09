/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 1, 2018 10:01 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkOrderViewComponent } from './work-order-view/work-order-view.component';
import { WorkOrderFormComponent } from './work-order-form/work-order-form.component';
import { FinishedOrderFormComponent } from './finished-order-form/finished-order-form.component';
import { PendingOrdersViewComponent } from './pending-orders-view/pending-orders-view.component';
import { RequestedWorkOrderFormComponent } from './requested-work-order-form/requested-work-order-form.component';

const routes: Routes = [
  { path: '', component: WorkOrderViewComponent },
  { path: 'new', component: WorkOrderFormComponent },
  { path: 'pending', component: PendingOrdersViewComponent },
  { path: 'completed', component: FinishedOrderFormComponent },
  {path: 'request/:salesOrderId', component: RequestedWorkOrderFormComponent},
  { path: ':workOrderId/update', component: WorkOrderFormComponent }


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkOrderRoutingModule { }
