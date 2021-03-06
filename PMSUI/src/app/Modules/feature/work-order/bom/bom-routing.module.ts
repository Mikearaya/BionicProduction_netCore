import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BomViewComponent } from './bom-view/bom-view.component';
import { BomFormComponent } from './bom-form/bom-form.component';

const routes: Routes = [
  { path: '', component: BomViewComponent },
  { path: 'new', component: BomFormComponent },
  { path: 'new/:itemId', component: BomFormComponent },
  { path: ':bomId/update', component: BomFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BOMRoutingModule { }
