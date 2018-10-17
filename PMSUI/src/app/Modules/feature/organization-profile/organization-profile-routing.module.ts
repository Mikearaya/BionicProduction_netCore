import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyProfileViewComponent } from './company-profile-view/company-profile-view.component';
import { CompanyProfileFormComponent } from './company-profile-form/company-profile-form.component';

const routes: Routes = [
  {path: '', component: CompanyProfileViewComponent },
  {path: ':organizationId/edit', component: CompanyProfileFormComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrganizationProfileRoutingModule { }
