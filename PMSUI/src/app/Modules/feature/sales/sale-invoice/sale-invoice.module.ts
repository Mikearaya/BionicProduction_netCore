import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaleInvoiceRoutingModule } from './sale-invoice-routing.module';
import { SaleInvoiceFormComponent } from './sale-invoice-form/sale-invoice-form.component';
import { SaleInvoiceApiService } from './sale-invoice-api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    SaleInvoiceRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [SaleInvoiceFormComponent],
  providers: [SaleInvoiceApiService]
})
export class SaleInvoiceModule { }
