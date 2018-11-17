import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShipmentViewComponent } from './shipment-view/shipment-view.component';
import { ShipmentFormComponent } from './shipment-form/shipment-form.component';

const routes: Routes = [
  { path: '', component: ShipmentViewComponent },
  { path: 'new', component: ShipmentFormComponent },
  { path: 'customerorder/:customerOrderId', component: ShipmentFormComponent },
  { path: ':shipmentId', component: ShipmentFormComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShipmentRoutingModule { }
