import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PmsNavigationModule } from './Modules/Core/pms-navigation/pms-navigation.module';

const routes: Routes = [
  { path: 'home', loadChildren: './Modules/Core/pms-navigation/pms-navigation.module#PmsNavigationModule' },
  { path: '**', redirectTo: 'home/dashboard' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
