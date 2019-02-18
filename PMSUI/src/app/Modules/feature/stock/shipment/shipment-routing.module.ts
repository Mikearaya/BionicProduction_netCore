import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShipmentViewComponent } from './shipment-view/shipment-view.component';
import { ShipmentFormComponent } from './shipment-form/shipment-form.component';
import { ShipmentDetailViewComponent } from './shipment-detail-view/shipment-detail-view.component';

const routes: Routes = [
  {
    path: '', component: ShipmentViewComponent,
    data: { title: 'Shipments List', breadCrum: 'Shipments' }
  },
  {
    path: 'new', component: ShipmentFormComponent,
    data: { title: 'Create new shipment', breadCrum: 'New' }
  },
  {
    path: ':shipmentId/update', component: ShipmentFormComponent,
    data: { title: 'Update shipment', breadCrum: 'Update' }
  },
  {
    path: 'customerorder/:customerOrderId', component: ShipmentFormComponent,
    data: { title: 'Customer order shipment', breadCrum: 'Customer order shipment' }
  },
  {
    path: ':shipmentId', component: ShipmentDetailViewComponent,
    data: { title: 'Shipment detail', breadCrum: 'Shipments detail' }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShipmentRoutingModule { }
