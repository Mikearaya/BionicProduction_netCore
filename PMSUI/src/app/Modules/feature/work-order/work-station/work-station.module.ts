import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkStationRoutingModule } from './work-station-routing.module';
import { WorkStationFormComponent } from './work-station-form/work-station-form.component';

import { WorkStationGroupViewComponent } from './work-station-group-view/work-station-group-view.component';
import { WorkStationViewComponent } from './work-station-view/work-station-view.component';
import { WorkStationGroupFormComponent } from './work-station-group-form/work-station-group-form.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    WorkStationFormComponent,
    WorkStationGroupFormComponent,
    WorkStationGroupViewComponent,
    WorkStationViewComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    WorkStationRoutingModule
  ]
})
export class WorkStationModule { }
