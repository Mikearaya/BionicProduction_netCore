import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseRecievingViewComponent } from './purchase-recieving-view/purchase-recieving-view.component';
import { PurchaseRecievingFormComponent } from './purchase-recieving-form/purchase-recieving-form.component';

const routes: Routes = [
  {
    path: '', component: PurchaseRecievingViewComponent,
    data: { title: 'Pending purchase orderes', breadCrum: '' }
  },
  {
    path: ':purchaseOrderId/new', component: PurchaseRecievingFormComponent,
    data: { title: 'New purchase recievings', breadCrum: 'New' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseRecievingRoutingModule { }
