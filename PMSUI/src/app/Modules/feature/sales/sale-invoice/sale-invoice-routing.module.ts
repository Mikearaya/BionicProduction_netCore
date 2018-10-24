import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SaleInvoiceFormComponent } from './sale-invoice-form/sale-invoice-form.component';

const routes: Routes = [
  {path: '', component: SaleInvoiceFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaleInvoiceRoutingModule { }
