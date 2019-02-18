import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EntryComponent } from './entry/entry.component';
import { CanActivate } from '@angular/router/src/utils/preactivation';
import { AuthrizationGuardGuard } from './authrization-guard.guard';

const routes: Routes = [
  {
    path: 'home', canActivate: [AuthrizationGuardGuard], component: EntryComponent
  },
  { path: 'error', loadChildren: './Modules/system/system.module#SystemModule' },
  {
    path: '', canActivate: [AuthrizationGuardGuard], loadChildren: './Modules/pms-navigation/pms-navigation.module#PmsNavigationModule',
    data: { title: 'Home', breadCrum: 'Home' }
  },



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
