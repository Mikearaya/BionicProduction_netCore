/*
 * @CreateTime: Dec 15, 2018 9:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 10:07 PM
 * @Description: Modify Here, Please
 */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StorageLocationViewComponent } from './storage-location-view/storage-location-view.component';
import { StorageLocationFormComponent } from './storage-location-form/storage-location-form.component';

const routes: Routes = [
  { path: '', component: StorageLocationViewComponent },
  { path: 'new', component: StorageLocationFormComponent },
  { path: ':storageId/update', component: StorageLocationFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StorageLocationRoutingModule { }
