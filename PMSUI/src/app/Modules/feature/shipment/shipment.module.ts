import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShipmentRoutingModule } from './shipment-routing.module';
import { ShipmentFormComponent } from './shipment-form/shipment-form.component';

import { ShipmentApiService } from '../../core/services/shipment/shipment-api.service';
import { SharedModule } from '../../shared/shared.module';
import { ShipmentViewComponent } from './shipment-view/shipment-view.component';
import { ShipmentDetailViewComponent } from './shipment-detail-view/shipment-detail-view.component';


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
