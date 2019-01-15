import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PmsNavigationRoutingModule } from './pms-navigation-routing.module';
import { TreeViewModule, SidebarModule } from '@syncfusion/ej2-angular-navigations';
import { PmsNavigationComponent } from './pms-navigation/pms-navigation.component';
import { SharedModule } from '../shared/shared.module';
import { DashboardModule } from '../feature/dashboard/dashboard.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    PmsNavigationRoutingModule,
    TreeViewModule,
    SidebarModule,
    DashboardModule,
  ],
  declarations: [PmsNavigationComponent]
})
export class PmsNavigationModule { }
