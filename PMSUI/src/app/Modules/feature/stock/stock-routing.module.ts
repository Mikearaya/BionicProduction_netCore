import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockComponent } from './stock.component';




const routes: Routes = [
  {
    path: '', component: StockComponent, children: [
      { path: '', loadChildren: './item/item.module#ItemModule' },
      { path: 'low-stock', loadChildren: './critical-item/critical-item.module#CriticalItemModule' },
      { path: 'inventory', loadChildren: './inventory/inventory.module#InventoryModule' },
      { path: 'stock-lots', loadChildren: './stock-batch/stock-batch.module#StockBatchModule' },
      { path: 'write-offs', loadChildren: './write-off/write-off.module#WriteOffModule' },
      { path: 'settings', loadChildren: './stock-setting/stock-setting.module#StockSettingModule' },
      { path: 'shipments', loadChildren: './shipment/shipment.module#ShipmentModule' },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockRoutingModule { }
