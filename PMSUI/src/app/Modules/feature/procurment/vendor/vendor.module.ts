import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorFormComponent } from './vendor-form/vendor-form.component';
import { VendorViewComponent } from './vendor-view/vendor-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';
import { VendorPurchaseTermViewComponent } from './vendor-purchase-term-view/vendor-purchase-term-view.component';

@NgModule({
  declarations: [
    VendorFormComponent,
    VendorViewComponent,
    VendorPurchaseTermViewComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    VendorRoutingModule
  ],
  providers: []
})
export class VendorModule { }
