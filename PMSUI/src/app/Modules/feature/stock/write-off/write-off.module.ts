import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WriteOffRoutingModule } from './write-off-routing.module';
import { WriteOffApiService } from './write-off-api.service';
import { WriteOffFormComponent } from './write-off-form/write-off-form.component';
import { WriteOffViewComponent } from './write-off-view/write-off-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    WriteOffFormComponent,
    WriteOffViewComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    WriteOffRoutingModule
  ],
  providers: [WriteOffApiService]
})
export class WriteOffModule { }
