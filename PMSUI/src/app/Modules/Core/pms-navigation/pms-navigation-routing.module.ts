import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PmsNavigationComponent } from './pms-navigation/pms-navigation.component';
import { PmsDashboardComponent } from './pms-dashboard/pms-dashboard.component';

const routes: Routes = [{
  path: '', component: PmsNavigationComponent, children: [
    { path: 'dashboard', component: PmsDashboardComponent },

    { path: 'customers', loadChildren: '../../feature/customer/customer.module#CustomerModule' },
    { path: 'workorders', loadChildren: '../../feature/work-order/work-order.module#WorkOrderModule' },
    { path: 'products', loadChildren: '../../feature/products/products.module#ProductsModule' },
    { path: 'employees', loadChildren: '../../feature/employee/employee.module#EmployeeModule' }

  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PmsNavigationRoutingModule { }