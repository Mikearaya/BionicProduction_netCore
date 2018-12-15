import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StorageLocationRoutingModule } from './storage-location-routing.module';
import { StorageLocationFormComponent } from './storage-location-form/storage-location-form.component';
import { StorageLocationViewComponent } from './storage-location-view/storage-location-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    StorageLocationFormComponent,
    StorageLocationViewComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    StorageLocationRoutingModule
  ]
})
export class StorageLocationModule { }
