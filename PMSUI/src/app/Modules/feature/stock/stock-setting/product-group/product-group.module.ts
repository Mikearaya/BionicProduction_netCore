import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductGroupRoutingModule } from './product-group-routing.module';
import { ProductGroupFormComponent } from './product-group-form/product-group-form.component';
import { ProductGroupViewComponent } from './product-group-view/product-group-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    ProductGroupFormComponent,
    ProductGroupViewComponent
  ],
  imports: [
    CommonModule,
    ProductGroupRoutingModule,
    SharedModule
  ]
})
export class ProductGroupModule { }
