import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleInvoiceFormComponent } from './sale-invoice-form/sale-invoice-form.component';
import { SalesInvoiceViewComponent } from './sales-invoice-view/sales-invoice-view.component';
import { InvoicePaymentComponent } from './invoice-payment/invoice-payment.component';


const routes: Routes = [
  {path: '', component: SalesInvoiceViewComponent},
  {path: 'customerorder/:customerOrderId', component: SaleInvoiceFormComponent},
  {path: 'update/:invoiceId', component: SaleInvoiceFormComponent},
  {path: 'create', component: SaleInvoiceFormComponent},
  {path: ':invoiceId/payments', component: InvoicePaymentComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaleInvoiceRoutingModule { }
