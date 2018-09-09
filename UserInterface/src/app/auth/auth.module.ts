import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth.component';
import { RouterModule } from '@angular/router';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTabsModule } from '@angular/material';

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

import { appRoutes } from './lazyloader.routes';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    suppressScrollX: true
};

import { DashboardCrmModule } from '../dashboard-crm/dashboard-crm.module';

import { CoreModule } from '../core/core.module';
import { EmployeeModule } from '../Modules/employee/employee.module';
import { CustomerModule } from '../Modules/customer/customer.module';
import { SharedModule } from '../Modules/shared/shared.module';
import { ProductsModule } from '../Modules/products/products.module';


@NgModule({
    imports: [
        CommonModule,
        SharedModule,
        CustomerModule,
        ProductsModule,
        EmployeeModule,
        RouterModule.forRoot(appRoutes),
        MatToolbarModule,
        DashboardCrmModule,
        CoreModule,
        MatSidenavModule,
        PerfectScrollbarModule,
    ],
    declarations: [AuthComponent],
    exports: [AuthComponent],
    providers: [
        {
            provide: PERFECT_SCROLLBAR_CONFIG,
            useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
        }
    ]
})
export class AuthModule { }
