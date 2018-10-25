import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleInvoiceFormComponent } from './sale-invoice-form/sale-invoice-form.component';
import { SalesInvoiceViewComponent } from './sales-invoice-view/sales-invoice-view.component';


const routes: Routes = [
  {path: '', component: SalesInvoiceViewComponent},
  {path: 'customerorder/:customerOrderId', component: SaleInvoiceFormComponent},
  {path: 'update/:invoiceId', component: SaleInvoiceFormComponent},
  {path: 'new', component: SaleInvoiceFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaleInvoiceRoutingModule { }
