/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 2:12 AM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkOrderRoutingModule } from './work-order-routing.module';
import { WorkOrderAPIService } from './work-order-api.service';

import { WorkOrderFormComponent } from './work-order-form/work-order-form.component';
import { WorkOrderViewComponent } from './work-order-view/work-order-view.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../../shared/shared.module';
import { FinishedOrderFormComponent } from './finished-order-form/finished-order-form.component';
import { FinishedOrderApiService } from './finished-order-api.service';
import { PendingOrdersViewComponent } from './pending-orders-view/pending-orders-view.component';
import { WorkStationModule } from './work-station/work-station.module';
import { ProductionRoutingModule } from './production-routing/production-routing.module';
import { ProductionComponent } from './production.component';




@NgModule({
  imports: [
    // angular
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    WorkOrderRoutingModule,

    // application
    ProductionRoutingModule,
    WorkStationModule,
    SharedModule
  ],
  declarations: [
    // application
    WorkOrderFormComponent,
    FinishedOrderFormComponent,
    WorkOrderViewComponent,
    PendingOrdersViewComponent,
    ProductionComponent

  ],
  providers: [
    FinishedOrderApiService,
    // application
    WorkOrderAPIService,
    // syncfusion
  ]
})
export class WorkOrderModule { }
