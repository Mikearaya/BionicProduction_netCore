import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductionRoutingRoutingModule } from './production-routing-routing.module';
import { SharedModule } from 'src/app/Modules/shared/shared.module';
import { RoutingFormComponent } from './routing-form/routing-form.component';
import { RoutingViewComponent } from './routing-view/routing-view.component';


@NgModule({
  declarations: [RoutingFormComponent, RoutingViewComponent],
  imports: [
    CommonModule,
    SharedModule,
    ProductionRoutingRoutingModule
  ]
})
export class ProductionRoutingModule { }
