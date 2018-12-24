import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendorRoutingModule } from './vendor-routing.module';
import { VendorFormComponent } from './vendor-form/vendor-form.component';
import { VendorViewComponent } from './vendor-view/vendor-view.component';
import { VendorApiService } from './vendor-api.service';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [VendorFormComponent, VendorViewComponent],
  imports: [
    CommonModule,
    SharedModule,
    VendorRoutingModule
  ],
  providers: [VendorApiService]
})
export class VendorModule { }
