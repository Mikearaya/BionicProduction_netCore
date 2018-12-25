import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PurchaseTermRoutingModule } from './purchase-term-routing.module';
import { PurchaseTermFormComponent } from './purchase-term-form/purchase-term-form.component';
import { PurchaseTermViewComponent } from './purchase-term-view/purchase-term-view.component';
import { PurchaseTermApiService } from './purchase-term-api.service';

@NgModule({
  declarations: [PurchaseTermFormComponent, PurchaseTermViewComponent],
  imports: [
    CommonModule,
    PurchaseTermRoutingModule
  ],
  providers: [PurchaseTermApiService]
})
export class PurchaseTermModule { }
