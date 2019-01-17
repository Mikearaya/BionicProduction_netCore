import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EntryComponent } from './entry/entry.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: 'home', component: EntryComponent
  },
  { path: '', loadChildren: './Modules/pms-navigation/pms-navigation.module#PmsNavigationModule' },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
