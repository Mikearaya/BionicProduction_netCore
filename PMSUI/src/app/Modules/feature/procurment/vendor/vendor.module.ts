import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorFormComponent } from './vendor-form/vendor-form.component';
import { VendorViewComponent } from './vendor-view/vendor-view.component';

@NgModule({
  declarations: [VendorFormComponent, VendorViewComponent],
  imports: [
    CommonModule,
    VendorRoutingModule
  ]
})
export class VendorModule { }
