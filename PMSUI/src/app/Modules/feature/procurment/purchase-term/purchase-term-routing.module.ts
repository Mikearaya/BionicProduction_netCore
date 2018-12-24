import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseTermViewComponent } from './purchase-term-view/purchase-term-view.component';
import { PurchaseTermFormComponent } from './purchase-term-form/purchase-term-form.component';

const routes: Routes = [
  { path: '', component: PurchaseTermViewComponent },
  { path: 'new', component: PurchaseTermFormComponent },
  { path: ':purchaseTermId/update', component: PurchaseTermFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseTermRoutingModule { }
