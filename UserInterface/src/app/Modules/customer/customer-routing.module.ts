/*
 * @CreateTime: Sep 5, 2018 8:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 8:51 PM
 * @Description: Modify Here, Please
 */

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerViewComponent } from './customer-view/customer-view.component';

const routes: Routes = [
                        {path: 'customers', component: CustomerViewComponent, data: {title: 'Customers List', customerSelfContained: true}},
                        {path: 'new/customer', component: CustomerFormComponent,
                        data: {title: 'Add New Customer', customerSelfContained: true}},
                        {path: 'update/customer/:id',
                        component: CustomerFormComponent, data: {title: 'Update Customer', customerSelfContained: true}
                      }
                      ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }