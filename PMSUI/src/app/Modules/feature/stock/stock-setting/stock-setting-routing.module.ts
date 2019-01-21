import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockSettingComponent } from './stock-setting.component';

const routes: Routes = [
  {
    path: '', component: StockSettingComponent, children: [
      { path: 'unit-of-measure', loadChildren: './unit-of-measurment/unit-of-measurment.module#UnitOfMeasurmentModule' },
      { path: 'product-groups', loadChildren: './product-group/product-group.module#ProductGroupModule' },
      { path: 'storages', loadChildren: './storage-location/storage-location.module#StorageLocationModule' },

    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockSettingRoutingModule { }
