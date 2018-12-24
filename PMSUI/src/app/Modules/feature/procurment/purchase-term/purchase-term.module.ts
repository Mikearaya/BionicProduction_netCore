import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PurchaseTermRoutingModule } from './purchase-term-routing.module';
import { PurchaseTermFormComponent } from './purchase-term-form/purchase-term-form.component';
import { PurchaseTermViewComponent } from './purchase-term-view/purchase-term-view.component';

@NgModule({
  declarations: [PurchaseTermFormComponent, PurchaseTermViewComponent],
  imports: [
    CommonModule,
    PurchaseTermRoutingModule
  ]
})
export class PurchaseTermModule { }
