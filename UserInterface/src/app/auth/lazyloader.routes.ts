import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth.component';
import { DashboardCrmComponent } from '../dashboard-crm/dashboard-crm.component';


export const appRoutes: Routes = [
  {  path: '', component: DashboardCrmComponent },
        {path: '**', redirectTo: ''}];
