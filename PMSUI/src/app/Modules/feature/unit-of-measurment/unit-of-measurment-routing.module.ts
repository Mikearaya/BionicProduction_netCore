import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnitOfMeasurmentViewComponent } from './unit-of-measurment-view/unit-of-measurment-view.component';
import { UnitOfMeasurmentFormComponent } from './unit-of-measurment-form/unit-of-measurment-form.component';

const routes: Routes = [
  { path: '', component: UnitOfMeasurmentViewComponent },
  { path: 'new', component: UnitOfMeasurmentFormComponent },
  { path: ':uomId/update', component: UnitOfMeasurmentFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UnitOfMeasurmentRoutingModule { }
