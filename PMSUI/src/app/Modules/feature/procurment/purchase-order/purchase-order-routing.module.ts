import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseOrderViewComponent } from './purchase-order-view/purchase-order-view.component';
import { PurchaseOrderFormComponent } from './purchase-order-form/purchase-order-form.component';

const routes: Routes = [
  {
    path: '', component: PurchaseOrderViewComponent,
    data: { title: 'Purchase Orders', breadCrum: '' }
  },
  {
    path: 'new', component: PurchaseOrderFormComponent,
    data: { title: 'Create a purchase order', breadCrum: 'new' }
  },
  {
    path: ':purchaseOrderId/update', component: PurchaseOrderFormComponent,
    data: { title: 'Update purchase order', breadCrum: 'update' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseOrderRoutingModule { }
