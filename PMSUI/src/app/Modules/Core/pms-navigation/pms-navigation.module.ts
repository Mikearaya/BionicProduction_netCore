import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PmsNavigationRoutingModule } from './pms-navigation-routing.module';
import { TreeViewModule, SidebarModule } from '@syncfusion/ej2-angular-navigations';
import { PmsDashboardComponent } from './pms-dashboard/pms-dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    PmsNavigationRoutingModule,
    TreeViewModule,
    SidebarModule
  ],
  declarations: [PmsDashboardComponent, PmsDashboardComponent]
})
export class PmsNavigationModule { }
