/*
 * @CreateTime: Jan 15, 2019 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 11:10 PM
 * @Description: Modify Here, Please
 */
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
