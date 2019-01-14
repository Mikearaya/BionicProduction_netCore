import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProcurmentComponent } from './procurment/procurment.component';

const routes: Routes = [
  {
    path: '', component: ProcurmentComponent, children: [
      { path: 'vendors', loadChildren: './vendor/vendor.module#VendorModule' },
      { path: 'purchase-terms', loadChildren: './purchase-term/purchase-term.module#PurchaseTermModule' },
      { path: 'purchase-orders', loadChildren: './purchase-order/purchase-order.module#PurchaseOrderModule' }
    ]
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProcurmentRoutingModule { }
