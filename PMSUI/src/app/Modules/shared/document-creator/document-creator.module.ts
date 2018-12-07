import { CommonModule } from '@angular/common';
import { CustomerInvoiceComponent } from './customer-invoice/customer-invoice.component';
import { NgModule } from '@angular/core';
import { PickingListComponent } from './picking-list/picking-list.component';
import { WayBillComponent } from './way-bill/way-bill.component';

@NgModule({
  declarations: [WayBillComponent, PickingListComponent, CustomerInvoiceComponent],
  imports: [
    CommonModule
  ],
  exports: [WayBillComponent, PickingListComponent, CustomerInvoiceComponent]
})
export class DocumentCreatorModule { }
