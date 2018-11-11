import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaleInvoiceRoutingModule } from './sale-invoice-routing.module';
import { SaleInvoiceFormComponent } from './sale-invoice-form/sale-invoice-form.component';
import { SaleInvoiceApiService } from './sale-invoice-api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { SalesInvoiceViewComponent } from './sales-invoice-view/sales-invoice-view.component';
import { SharedModule } from '../../shared/shared.module';
import { InvoicePaymentComponent } from './invoice-payment/invoice-payment.component';
import { InvoicePaymentsViewComponent } from './invoice-payments-view/invoice-payments-view.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    SaleInvoiceRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [SaleInvoiceFormComponent,
    SalesInvoiceViewComponent,
    InvoicePaymentsViewComponent,
    InvoicePaymentComponent],
  providers: [SaleInvoiceApiService]
})
export class SaleInvoiceModule { }
