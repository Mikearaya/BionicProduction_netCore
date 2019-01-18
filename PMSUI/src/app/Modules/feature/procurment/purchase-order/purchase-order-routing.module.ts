import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseOrderViewComponent } from './purchase-order-view/purchase-order-view.component';
import { PurchaseOrderFormComponent } from './purchase-order-form/purchase-order-form.component';

const routes: Routes = [
  {
    path: '', component: PurchaseOrderViewComponent,
    data: { title: 'Purchase Orders', breadcrum: 'procurments/purchase-orders' }
  },
  {
    path: 'new', component: PurchaseOrderFormComponent,
    data: { title: 'Create a purchase order', breadcrum: 'procuments/purchase-orders/new' }
  },
  {
    path: ':purchaseOrderId/Update', component: PurchaseOrderFormComponent,
    data: { title: 'Update purchase order', breadcrum: 'procuments/purchase-orders/update' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseOrderRoutingModule { }
