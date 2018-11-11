/*
 * @CreateTime: Nov 4, 2018 9:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 1:17 AM
 * @Description: Modify Here, Please
 */
import { Component, OnInit } from '@angular/core';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';
import { ActivatedRoute } from '@angular/router';
import { InvoicePaymentSummary, InvoicePayments } from '../sales-invoice-data-model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-invoice-payment',
  templateUrl: './invoice-payment.component.html',
  styleUrls: ['./invoice-payment.component.css']
})
export class InvoicePaymentComponent extends CommonProperties implements OnInit {

  public paymentForm: FormGroup;
  public invoice: InvoicePaymentSummary;
  private invoiceId: number;


  constructor(private saleInvoiceApi: SaleInvoiceApiService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) {
    super();
    this.createForm();
  }


  ngOnInit() {
    this.invoiceId = + this.activatedRoute.snapshot.paramMap.get('invoiceId');

    if (this.invoiceId) {
      this.saleInvoiceApi.getInvoiceSummary(this.invoiceId).subscribe(
        (data: InvoicePaymentSummary) => this.invoice = data,
        this.handleError
      );
    }

  }



  createForm(): void {
    this.paymentForm = this.formBuilder.group({
      paidAmount: ['', Validators.required]
    });
  }

  get paidAmount(): FormControl {
    return this.paymentForm.get('paidAmount') as FormControl;
  }


  onSubmit(): void {
    const payment = this.prepareForm(this.paymentForm.value);
    this.saleInvoiceApi.addInvoicePayment(payment).subscribe(
      (data: InvoicePayments) => alert('payment Added Successfuly'),
      this.handleError
    );
  }

  prepareForm(data: any): InvoicePayments {
    return {
      id: this.invoiceId,
      amount: data.paidAmount
    };
  }

}
