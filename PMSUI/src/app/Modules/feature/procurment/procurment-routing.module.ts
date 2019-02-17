import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProcurmentComponent } from './procurment.component';

const routes: Routes = [
  {
    path: '', component: ProcurmentComponent, children: [
      { path: '', redirectTo: 'purchase-orders', pathMatch: 'full' },
      {
        path: 'vendors', loadChildren: './vendor/vendor.module#VendorModule',
        data: { title: 'Vendors', breadCrum: 'vendors' }
      },
      {
        path: 'purchase-terms', loadChildren: './purchase-term/purchase-term.module#PurchaseTermModule',
        data: { title: 'Purchase terms', breadCrum: 'Purchase terms' }
      },
      {
        path: 'purchase-orders', loadChildren: './purchase-order/purchase-order.module#PurchaseOrderModule',
        data: { title: 'Purchase orders', breadCrum: 'Purchase orders' }
      }
    ]
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProcurmentRoutingModule { }
