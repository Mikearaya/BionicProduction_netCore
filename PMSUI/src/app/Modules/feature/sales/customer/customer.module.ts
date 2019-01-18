
import { NgModule } from '@angular/core';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerRoutingModule } from './customer-routing.module';

import { CustomerViewComponent } from './customer-view/customer-view.component';

import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  imports: [
    // application
    CustomerRoutingModule,
    // angular
    CommonModule,
    SharedModule

  ],
  declarations: [
    // application
    CustomerFormComponent,
    CustomerViewComponent],
  providers: [
    // application
    // syncfusion
  ],
  exports: []

})
export class CustomerModule { }
