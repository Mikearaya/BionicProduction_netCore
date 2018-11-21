import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PmsNavigationRoutingModule } from './pms-navigation-routing.module';
import { TreeViewModule, SidebarModule, ToolbarModule } from '@syncfusion/ej2-angular-navigations';
import { PmsNavigationComponent } from './pms-navigation/pms-navigation.component';
import { ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { SharedModule } from '../shared/shared.module';
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
    DashboardModule
  ],
  declarations: [PmsNavigationComponent]
})
export class PmsNavigationModule { }
