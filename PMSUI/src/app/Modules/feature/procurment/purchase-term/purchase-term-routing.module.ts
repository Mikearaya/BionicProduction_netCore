import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseTermFormComponent } from './purchase-term-form/purchase-term-form.component';

const routes: Routes = [
  { path: '', component: PurchaseTermFormComponent },
  { path: ':purchaseTermId/update', component: PurchaseTermFormComponent },
  { path: 'item/:itemId', component: PurchaseTermFormComponent },
  { path: 'vendor/:vendorId', component: PurchaseTermFormComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseTermRoutingModule { }
