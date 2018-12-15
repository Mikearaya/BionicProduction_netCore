import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkStationGroupViewComponent } from './work-station-group-view/work-station-group-view.component';
import { WorkStationViewComponent } from './work-station-view/work-station-view.component';
import { WorkStationGroupFormComponent } from './work-station-group-form/work-station-group-form.component';
import { WorkStationFormComponent } from './work-station-form/work-station-form.component';

const routes: Routes = [
  { path: '', component: WorkStationGroupViewComponent },
  { path: 'stations', component: WorkStationViewComponent },
  { path: 'new', component: WorkStationGroupFormComponent },
  { path: 'stations/new', component: WorkStationFormComponent },
  { path: ':workstationGroupId/update', component: WorkStationGroupFormComponent },
  { path: ':workstationGroupId/stations/:stationId', component: WorkStationFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkStationRoutingModule { }
