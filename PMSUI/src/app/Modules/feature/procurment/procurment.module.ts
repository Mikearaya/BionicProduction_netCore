import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProcurmentRoutingModule } from './procurment-routing.module';
import { ProcurmentComponent } from './procurment/procurment.component';

@NgModule({
  declarations: [ProcurmentComponent],
  imports: [
    CommonModule,
    ProcurmentRoutingModule
  ]
})
export class ProcurmentModule { }
