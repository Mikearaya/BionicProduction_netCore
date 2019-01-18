import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CriticalItemRoutingModule } from './critical-item-routing.module';
import { SharedModule } from 'src/app/Modules/shared/shared.module';
import { LowStockViewComponent } from './low-stock-view/low-stock-view.component';

@NgModule({
  declarations: [
    LowStockViewComponent
  ],
  imports: [
    CommonModule,
    CriticalItemRoutingModule,
    SharedModule
  ]
})
export class CriticalItemModule { }
