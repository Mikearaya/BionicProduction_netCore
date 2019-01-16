import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShipmentRoutingModule } from './shipment-routing.module';
import { ShipmentFormComponent } from './shipment-form/shipment-form.component';
import { ShipmentViewComponent } from './shipment-view/shipment-view.component';
import { ShipmentDetailViewComponent } from './shipment-detail-view/shipment-detail-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';


@NgModule({
  declarations: [
    ShipmentFormComponent,
    ShipmentDetailViewComponent,
    ShipmentViewComponent
  ],
  imports: [
    CommonModule,
    ShipmentRoutingModule,
    SharedModule
  ],
  providers: []
})
export class ShipmentModule { }
