import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleInvoiceFormComponent } from './sale-invoice-form/sale-invoice-form.component';
import { SalesInvoiceViewComponent } from './sales-invoice-view/sales-invoice-view.component';
import { InvoicePaymentComponent } from './invoice-payment/invoice-payment.component';


const routes: Routes = [
  {
    path: '', component: SalesInvoiceViewComponent,
    data: { title: 'Invoices', breadCrum: 'Invoices' }
  },
  {
    path: ':invoiceId/payments', component: InvoicePaymentComponent,
    data: { title: 'Invoices payment', breadCrum: 'invoice payments' }
  },
  {
    path: 'create', component: SaleInvoiceFormComponent,
    data: { title: 'Create invoice', breadCrum: 'New' }
  },
  {
    path: 'customerorder/:customerOrderId', component: SaleInvoiceFormComponent,
    data: { title: 'Customer order invoice', breadCrum: 'Customer order invoice' }
  },
  {
    path: ':invoiceId/update', component: SaleInvoiceFormComponent,
    data: { title: 'Update invoice', breadCrum: 'Update' }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaleInvoiceRoutingModule { }
