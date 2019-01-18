/*
 * @CreateTime: Jan 15, 2019 11:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 11:09 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductGroupFormComponent } from './product-group-form/product-group-form.component';
import { ProductGroupViewComponent } from './product-group-view/product-group-view.component';

const routes: Routes = [
  { path: '', component: ProductGroupViewComponent },
  { path: 'new', component: ProductGroupFormComponent },
  { path: ':productGroupId/update', component: ProductGroupFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductGroupRoutingModule { }
