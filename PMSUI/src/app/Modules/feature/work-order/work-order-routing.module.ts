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
import { WorkOrderFormComponent } from './work-order-form/work-order-form.component';
import { FinishedOrderFormComponent } from './finished-order-form/finished-order-form.component';
import { PendingOrdersViewComponent } from './pending-orders-view/pending-orders-view.component';
import { ProductionComponent } from './production.component';
import { WorkOrderViewComponent } from './work-order-view/work-order-view.component';

const routes: Routes = [
  {
    path: '', component: ProductionComponent, children: [
      { path: '', redirectTo: 'work-orders', pathMatch: 'full' },
      { path: 'work-orders', component: WorkOrderViewComponent },
      { path: 'routings', loadChildren: './production-routing/production-routing.module#ProductionRoutingModule' },
      { path: 'boms', loadChildren: './bom/bom.module#BOMModule' },
      { path: 'workstations', loadChildren: './work-station/work-station.module#WorkStationModule' },
      { path: 'work-orders/new', component: WorkOrderFormComponent },
      { path: 'work-orders/:workOrderId/update', component: WorkOrderFormComponent },

      { path: 'pending', component: PendingOrdersViewComponent },
      { path: 'completed', component: FinishedOrderFormComponent },
      { path: 'request/:customerOrderId', component: WorkOrderFormComponent },
      { path: 'item/:itemId', component: WorkOrderFormComponent },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkOrderRoutingModule { }
