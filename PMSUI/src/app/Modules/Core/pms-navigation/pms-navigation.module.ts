import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PmsNavigationRoutingModule } from './pms-navigation-routing.module';
import { TreeViewModule, SidebarModule } from '@syncfusion/ej2-angular-navigations';
import { PmsDashboardComponent } from './pms-dashboard/pms-dashboard.component';
import { PmsNavigationComponent } from './pms-navigation/pms-navigation.component';
import { ButtonModule } from '@syncfusion/ej2-ng-buttons';

@NgModule({
  imports: [
    CommonModule,
    PmsNavigationRoutingModule,
    TreeViewModule,
    ButtonModule,
    SidebarModule
  ],
  declarations: [PmsDashboardComponent, PmsNavigationComponent]
})
export class PmsNavigationModule { }
