import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InventoryRoutingModule } from './inventory-routing.module';
import { SharedModule } from 'src/app/Modules/shared/shared.module';
import { InventoryViewComponent } from './inventory-view/inventory-view.component';
import { InventoryApiService } from './inventory-api.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [InventoryViewComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    InventoryRoutingModule
  ],
  providers: [InventoryApiService]
})
export class InventoryModule { }
