import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoutingViewComponent } from './routing-view/routing-view.component';
import { RoutingFormComponent } from './routing-form/routing-form.component';

const routes: Routes = [
  { path: '', component: RoutingViewComponent },
  { path: 'new', component: RoutingFormComponent },
  { path: ':routingId/update', component: RoutingFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductionRoutingRoutingModule { }
