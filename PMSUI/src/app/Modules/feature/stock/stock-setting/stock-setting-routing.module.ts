import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StockSettingComponent } from './stock-setting.component';

const routes: Routes = [
  {
    path: '', component: StockSettingComponent, children: [
      {
        path: 'unit-of-measure', loadChildren: './unit-of-measurment/unit-of-measurment.module#UnitOfMeasurmentModule',
        data: { title: 'Unit of measurments', breadCrum: 'UOMs' }
      },
      {
        path: 'product-groups', loadChildren: './product-group/product-group.module#ProductGroupModule',
        data: { title: 'Product groups', breadCrum: 'Product group' }
      },
      {
        path: 'storages', loadChildren: './storage-location/storage-location.module#StorageLocationModule',
        data: { title: 'Storage locetions', breadCrum: 'storage locations' }
      },

    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StockSettingRoutingModule { }

