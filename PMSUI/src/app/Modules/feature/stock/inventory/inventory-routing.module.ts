import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InventoryViewComponent } from './inventory-view/inventory-view.component';

const routes: Routes = [
  { path: '', component: InventoryViewComponent, data: { title: 'Inventory' } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule { }
