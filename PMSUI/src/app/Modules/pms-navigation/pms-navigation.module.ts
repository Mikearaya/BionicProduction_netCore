import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PmsNavigationRoutingModule } from './pms-navigation-routing.module';
import { TreeViewModule, SidebarModule, ToolbarModule } from '@syncfusion/ej2-angular-navigations';
import { PmsDashboardComponent } from './pms-dashboard/pms-dashboard.component';
import { PmsNavigationComponent } from './pms-navigation/pms-navigation.component';
import { ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { SharedModule } from '../shared/shared.module';
import { BionicChartsModule } from '../feature/bionic-charts/bionic-charts.module';
import { DashboardModule } from '../feature/dashboard/dashboard.module';

@NgModule({
  imports: [
    CommonModule,
    ToolbarModule,
    SharedModule,
    PmsNavigationRoutingModule,
    TreeViewModule,
    ButtonModule,
    SidebarModule,
    BionicChartsModule,
    DashboardModule
  ],
  declarations: [PmsDashboardComponent, PmsNavigationComponent]
})
export class PmsNavigationModule { }
