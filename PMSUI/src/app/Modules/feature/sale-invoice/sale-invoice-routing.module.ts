import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleInvoiceFormComponent } from './sale-invoice-form/sale-invoice-form.component';
import { SalesInvoiceViewComponent } from './sales-invoice-view/sales-invoice-view.component';
import { InvoicePaymentComponent } from './invoice-payment/invoice-payment.component';
import { InvoicePaymentsViewComponent } from './invoice-payments-view/invoice-payments-view.component';


const routes: Routes = [
  {path: '', component: SalesInvoiceViewComponent},
  {path: ':invoiceId/payments', component: InvoicePaymentComponent},
  {path: 'create', component: SaleInvoiceFormComponent},
  {path: 'customerorder/:customerOrderId', component: SaleInvoiceFormComponent},
  {path: ':invoiceId', component: SaleInvoiceFormComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaleInvoiceRoutingModule { }
