/*
 * @CreateTime: Dec 15, 2018 9:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 9:56 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PmsNavigationComponent } from './pms-navigation/pms-navigation.component';
import { DashboardComponent } from '../feature/dashboard/dashboard/dashboard.component';

const routes: Routes = [{
  path: '', component: PmsNavigationComponent, children: [
    { path: '', component: DashboardComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'customers', loadChildren: '../feature/customer/customer.module#CustomerModule' },
    { path: 'workorders', loadChildren: '../feature/work-order/work-order.module#WorkOrderModule' },
    { path: 'products', loadChildren: '../feature/products/products.module#ProductsModule' },
    { path: 'employees', loadChildren: '../feature/employee/employee.module#EmployeeModule' },
    { path: 'stocks', loadChildren: '../feature/stock/stock.module#StockModule' },
    { path: 'sales', loadChildren: '../feature/sales/sales.module#SalesModule' },
    { path: 'invoices', loadChildren: '../feature/sale-invoice/sale-invoice.module#SaleInvoiceModule' },
    { path: 'profile', loadChildren: '../feature/organization-profile/organization-profile.module#OrganizationProfileModule' },
    { path: 'shipments', loadChildren: '../feature/shipment/shipment.module#ShipmentModule' },
    { path: 'unit-of-measure', loadChildren: '../feature/unit-of-measurment/unit-of-measurment.module#UnitOfMeasurmentModule' },
    { path: 'boms', loadChildren: '../feature/stock/bom/bom.module#BOMModule' },
    { path: 'work-stations', loadChildren: '../feature/work-order/work-station/work-station.module#WorkStationModule' },
    { path: 'routings', loadChildren: '../feature/work-order/production-routing/production-routing.module#ProductionRoutingModule' },
    { path: 'storages', loadChildren: '../feature/stock/storage-location/storage-location.module#StorageLocationModule' },


  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PmsNavigationRoutingModule { }
