import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemRoutingModule } from './system-routing.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { ForbidenAccessComponent } from './forbiden-access/forbiden-access.component';
import { UnauthorizedAccessComponent } from './unauthorized-access/unauthorized-access.component';
import { ServerErrorComponent } from './server-error/server-error.component';

@NgModule({
  declarations: [
    NotFoundComponent,
    ForbidenAccessComponent,
    UnauthorizedAccessComponent,
    ServerErrorComponent
  ],
  imports: [
    CommonModule,
    SystemRoutingModule
  ]
})
export class SystemModule { }
