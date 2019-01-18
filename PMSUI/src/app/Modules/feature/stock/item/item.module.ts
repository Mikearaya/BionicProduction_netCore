import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ItemRoutingModule } from './item-routing.module';
import { StockFormComponent } from './stock-form/stock-form.component';
import { StockViewComponent } from './stock-view/stock-view.component';
import { ItemBomListViewComponent } from './item-bom-list-view/item-bom-list-view.component';
import { ItemPurchaseTermViewComponent } from './item-purchase-term-view/item-purchase-term-view.component';
import { ItemRoutingListViewComponent } from './item-routing-list-view/item-routing-list-view.component';
import { SharedModule } from 'src/app/Modules/shared/shared.module';

@NgModule({
  declarations: [
    StockFormComponent,
    StockViewComponent,
    ItemBomListViewComponent,
    ItemPurchaseTermViewComponent,
    ItemRoutingListViewComponent
  ],
  imports: [
    CommonModule,
    ItemRoutingModule,
    SharedModule
  ]
})
export class ItemModule { }
