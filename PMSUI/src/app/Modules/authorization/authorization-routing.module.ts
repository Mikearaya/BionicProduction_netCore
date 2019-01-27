import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LogInComponent } from './log-in/log-in.component';
import { AuthrizationService } from './authrization.service';

const routes: Routes = [
  { path: 'login', component: LogInComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthrizationService]
})
export class AuthorizationRoutingModule { }
