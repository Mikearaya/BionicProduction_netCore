import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseRecievingViewComponent } from './purchase-recieving-view/purchase-recieving-view.component';

const routes: Routes = [
  {
    path: '', component: PurchaseRecievingViewComponent,
    data: { title: 'Pending purchase orderes', breadCrum: '' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchaseRecievingRoutingModule { }
