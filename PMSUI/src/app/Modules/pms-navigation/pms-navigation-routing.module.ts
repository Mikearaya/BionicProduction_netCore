/*
 * @CreateTime: Dec 15, 2018 9:56 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 11:37 PM
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
    { path: 'workorders', loadChildren: '../feature/work-order/work-order.module#WorkOrderModule' },
    { path: 'employees', loadChildren: '../feature/employee/employee.module#EmployeeModule' },
    { path: 'stocks', loadChildren: '../feature/stock/stock.module#StockModule' },
    { path: 'crm', loadChildren: '../feature/sales/sales.module#SalesModule' },
    { path: 'profile', loadChildren: '../feature/organization-profile/organization-profile.module#OrganizationProfileModule' },
    { path: 'boms', loadChildren: '../feature/work-order/bom/bom.module#BOMModule' },
    { path: 'work-stations', loadChildren: '../feature/work-order/work-station/work-station.module#WorkStationModule' },
    { path: 'routings', loadChildren: '../feature/work-order/production-routing/production-routing.module#ProductionRoutingModule' },
    { path: 'procurments', loadChildren: '../feature/procurment/procurment.module#ProcurmentModule' },


  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PmsNavigationRoutingModule { }
