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
    { path: 'employees', loadChildren: '../feature/employee/employee.module#EmployeeModule' },
    { path: 'productions', loadChildren: '../feature/work-order/work-order.module#WorkOrderModule' },
    { path: 'stocks', loadChildren: '../feature/stock/stock.module#StockModule' },
    { path: 'crm', loadChildren: '../feature/sales/sales.module#SalesModule' },
    { path: 'procurments', loadChildren: '../feature/procurment/procurment.module#ProcurmentModule' },
    { path: 'profile', loadChildren: '../feature/organization-profile/organization-profile.module#OrganizationProfileModule' },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PmsNavigationRoutingModule { }
