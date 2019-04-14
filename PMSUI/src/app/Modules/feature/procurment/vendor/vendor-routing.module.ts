import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendorViewComponent } from './vendor-view/vendor-view.component';
import { VendorFormComponent } from './vendor-form/vendor-form.component';

const routes: Routes = [
  {
    path: '',
    component: VendorViewComponent,
    data: { title: 'Vendors', breadCrum: '' }
  },
  {
    path: 'new',
    component: VendorFormComponent,
    data: { title: 'New vendor', breadCrum: 'New' }
  },
  {
    path: ':vendorId/update',
    component: VendorFormComponent,
    data: { title: 'Update vendor', breadCrum: 'Update' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule {}
