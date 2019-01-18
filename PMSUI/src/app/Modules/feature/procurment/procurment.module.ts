import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProcurmentRoutingModule } from './procurment-routing.module';
import { ProcurmentComponent } from './procurment.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [ProcurmentComponent],
  imports: [
    CommonModule,
    ProcurmentRoutingModule,
    SharedModule
  ]
})
export class ProcurmentModule { }
