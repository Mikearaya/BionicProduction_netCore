import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseTermFormComponent } from './purchase-term-form/purchase-term-form.component';

const routes: Routes = [
  {
    path: '', component: PurchaseTermFormComponent,
    data: { title: '', breadCrum: 'Purchase terms' }
  },
  {
    path: ':purchaseTermId/update', component: PurchaseTermFormComponent,
    data: { title: 'Update purchase term', breadCrum: 'Update' }
  },
  {
    path: 'item/:itemId', component: PurchaseTermFormComponent,
    data: { title: 'Item purchase term', breadCrum: 'New' }
  },
  {
    path: 'vendor/:vendorId', component: PurchaseTermFormComponent,
    data: { title: 'Vendor purchase term', breadCrum: 'New' }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseTermRoutingModule { }
