import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { ForbidenAccessComponent } from './forbiden-access/forbiden-access.component';
import { UnauthorizedAccessComponent } from './unauthorized-access/unauthorized-access.component';
import { ServerErrorComponent } from './server-error/server-error.component';

const routes: Routes = [
  { path: 'not-found', component: NotFoundComponent },
  { path: 'forbiden', component: ForbidenAccessComponent },
  { path: 'unauthorized', component: UnauthorizedAccessComponent },
  { path: 'server-error', component: ServerErrorComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemRoutingModule { }
