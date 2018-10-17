import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {  OrganizationProfileRoutingModule } from './organization-profile-routing.module';
import { CompanyProfileService } from './company-profile.service';
import { CompanyProfileFormComponent } from './company-profile-form/company-profile-form.component';
import { CompanyProfileViewComponent } from './company-profile-view/company-profile-view.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    OrganizationProfileRoutingModule
  ],
  declarations: [CompanyProfileFormComponent, CompanyProfileViewComponent],
  providers: [CompanyProfileService]
})
export class OrganizationProfileModule { }
