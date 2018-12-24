import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendorViewComponent } from './vendor-view/vendor-view.component';
import { VendorFormComponent } from './vendor-form/vendor-form.component';

const routes: Routes = [
  { path: '', component: VendorViewComponent },
  { path: 'new', component: VendorFormComponent },
  { path: ':vendorId/update', component: VendorFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule { }
