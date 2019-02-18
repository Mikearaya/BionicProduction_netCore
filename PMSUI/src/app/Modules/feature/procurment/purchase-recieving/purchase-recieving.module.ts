import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PurchaseRecievingRoutingModule } from './purchase-recieving-routing.module';
import { PurchaseRecievingViewComponent } from './purchase-recieving-view/purchase-recieving-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    PurchaseRecievingViewComponent
  ],
  imports: [
    CommonModule,
    PurchaseRecievingRoutingModule,
    SharedModule
  ]
})
export class PurchaseRecievingModule { }
