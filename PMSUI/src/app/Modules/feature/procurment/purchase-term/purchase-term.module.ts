import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PurchaseTermRoutingModule } from './purchase-term-routing.module';
import { PurchaseTermFormComponent } from './purchase-term-form/purchase-term-form.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [PurchaseTermFormComponent],
  imports: [
    CommonModule,
    SharedModule,
    PurchaseTermRoutingModule
  ],
  providers: []
})
export class PurchaseTermModule { }
