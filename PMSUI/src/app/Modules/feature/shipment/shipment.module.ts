import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShipmentRoutingModule } from './shipment-routing.module';
import { ShipmentFormComponent } from './shipment-form/shipment-form.component';

import { ShipmentApiService } from './shipment-api.service';
import { SharedModule } from '../../shared/shared.module';
import { ShipmentViewComponent } from './shipment-view/shipment-view.component';
import { ShipmentSummaryViewComponent } from './shipment-summary-view/shipment-summary-view.component';

@NgModule({
  declarations: [
    ShipmentFormComponent,
    ShipmentSummaryViewComponent,
    ShipmentViewComponent
  ],
  imports: [
    CommonModule,
    ShipmentRoutingModule,
    SharedModule
  ],
  providers: [ShipmentApiService]
})
export class ShipmentModule { }
