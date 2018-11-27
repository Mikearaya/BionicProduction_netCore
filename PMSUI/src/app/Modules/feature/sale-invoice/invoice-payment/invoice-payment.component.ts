/*
 * @CreateTime: Nov 4, 2018 9:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 26, 2018 10:20 PM
 * @Description: Modify Here, Please
 */
import { ActivatedRoute } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import {
  DataManager,
  Query,
  ReturnOption,
  WebApiAdaptor
  } from '@syncfusion/ej2-data';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
  } from '@angular/forms';
import { InvoicePayments, InvoicePaymentSummary } from '../sales-invoice-data-model';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';



@Component({
  selector: 'app-invoice-payment',
  templateUrl: './invoice-payment.component.html',
  styleUrls: ['./invoice-payment.component.css']
})
export class InvoicePaymentComponent extends CommonProperties implements OnInit {
  @ViewChild('notification') notification: NotificationComponent;
  public paymentForm: FormGroup;
  public invoice: InvoicePaymentSummary;
  private invoiceId: number;
  cashierList: Object[];
  cashierQuery: Query;
  cashierFields: { text: string; value: string; };


  constructor(private saleInvoiceApi: SaleInvoiceApiService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    @Inject('EMPLOYEE_API_URL') private employeeApiUrl: string) {
    super();
    this.createForm();
    this.cashierQuery = new Query().select(['firstName', 'id']);
    this.cashierFields = { text: 'firstName', value: 'id' };
  }


  ngOnInit(): void {
    this.invoiceId = + this.activatedRoute.snapshot.paramMap.get('invoiceId');

    if (this.invoiceId) {
      this.saleInvoiceApi.getInvoiceSummary(this.invoiceId).subscribe(
        (data: InvoicePaymentSummary) => this.invoice = data,
        this.handleError
      );
    }

    const dm: DataManager = new DataManager(
      { url: this.employeeApiUrl, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    dm.ready.then((e: ReturnOption) => this.cashierList = <Object[]>e.result).catch((e) => true);
  }



  createForm(): void {
    this.paymentForm = this.formBuilder.group({
      paidAmount: ['', Validators.required],
      cashier: ['', Validators.required],
      note: ['']
    });
  }

  get paidAmount(): FormControl {
    return this.paymentForm.get('paidAmount') as FormControl;
  }

  get cashier(): FormControl {
    return this.paymentForm.get('cashier') as FormControl;
  }


  onSubmit(): void {
    const payment = this.prepareForm(this.paymentForm.value);
    this.saleInvoiceApi.addInvoicePayment(payment).subscribe(
      (data: InvoicePayments) => this.notification.showMessage( 'Payment Saved Successfuly'),
      this.handleError
    );
  }

  prepareForm(data: any): InvoicePayments {
    return {
      id: this.invoiceId,
      amount: data.paidAmount,
      cashierId: data.cashier,
      note: data.note
    };
  }

}
