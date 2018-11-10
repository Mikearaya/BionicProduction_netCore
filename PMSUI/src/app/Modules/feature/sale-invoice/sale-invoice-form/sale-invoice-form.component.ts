import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';
import { DataManager, WebApiAdaptor, Query, ReturnOption } from '@syncfusion/ej2-data';
import { ActivatedRoute } from '@angular/router';

import { CustomerOrder } from '../../../core/DataModels/customer-order-data-models';
import { Invoice } from '../sales-invoice-data-model';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Location } from '@angular/common';

@Component({
  selector: 'app-sale-invoice-form',
  templateUrl: './sale-invoice-form.component.html',
  styleUrls: ['./sale-invoice-form.component.css']
})

export class SaleInvoiceFormComponent extends CommonProperties implements OnInit {
  public saleInvoiceForm: FormGroup;
  public discount: number;
  public totalTax: number;
  public totalBeforeTax: number;
  public totalAfterTax: number;
  public totalQuantity: number;
  public taxAmount: number;
  public invoiceTypes = ['Quotation', 'Pro-forma invoice', 'Invoice', 'Credit-invoice', 'Order confirmation'];
  public invoiceStatus = ['Paid', 'Not Paid'];
  public customersList: Object[];
  public itemsList: Object[];
  public employeesList: Object[];
  public customersQuery: Query;
  public customerFields: { text: string; value: string; };
  public employeeQuery: Query;
  public employeeFields: { text: string; value: string; };
  public itemQuery: Query;
  public itemFields: { text: string; value: string; };
  public customerOrderFields: { text: string; value: string; };
  public customerOrderQuery: Query;
  public customerOrdersList: Object[];
  public submitButtonText = 'Save';


  private orderId: number;
  private invoiceId: number;


  constructor(private formBuilder: FormBuilder,
    private saleInvoiceApi: SaleInvoiceApiService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    @Inject('EMPLOYEE_API_URL') private employeeApiUrl: string,
    @Inject('BASE_URL') private apiUrl: string) {

    super();

    this.createForm();
    this.customersQuery = new Query().select(['firstName', 'id']);
    this.customerFields = { text: 'firstName', value: 'id' };
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['code', 'id']);
    this.itemFields = { text: 'code', value: 'id' };
    this.customerOrderQuery = new Query().select(['customerName', 'id']);
    this.customerOrderFields = { text: 'id', value: 'id' };
  }

  ngOnInit() {
    this.orderId = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');
    this.invoiceId = + this.activatedRoute.snapshot.paramMap.get('invoiceId');

    if (this.customerOrderId) {
      this.saleInvoiceApi.getCustomerOrder(this.orderId).subscribe(
        (data: CustomerOrder) => this.initializeForm(data),
        this.handleError
      );
    }

    this.items.valueChanges
      .subscribe((data: any[]) => {
        this.discount = 0;
        this.totalQuantity = 0;
        this.totalBeforeTax = 0;
        this.totalAfterTax = 0;
        this.taxAmount = 0;
        data.forEach(element => {
          this.discount += element.discount;
          this.totalQuantity += element.quantity;
          this.totalBeforeTax += element.quantity * element.unitPrice;
        });


      });

    const employeeDataManaget: DataManager = new DataManager(
      { url: this.employeeApiUrl, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    employeeDataManaget.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);

    const itemDataManager: DataManager = new DataManager(
      { url: `${this.apiUrl}/products`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    itemDataManager.ready.then((e: ReturnOption) => this.itemsList = <Object[]>e.result).catch((e) => true);

    const customerDataManager: DataManager = new DataManager(
      { url: `${this.apiUrl}/customers`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    customerDataManager.ready.then((e: ReturnOption) => this.customersList = <Object[]>e.result).catch((e) => true);

    const customerOrderDataManager: DataManager = new DataManager(
      { url: `${this.apiUrl}/salesorders`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    customerOrderDataManager.ready.then((e: ReturnOption) => this.customerOrdersList = <Object[]>e.result).catch((e) => true);


  }

  get items(): FormArray {
    return this.saleInvoiceForm.get('InvoiceItems') as FormArray;
  }
  invoiceItems(): FormGroup {
    return this.formBuilder.group({
      itemId: ['', Validators.required],
      quantity: [0, Validators.required],
      unitPrice: [0, Validators.required],
      discount: [0],
      note: ['']
    });
  }

  createForm() {
    this.saleInvoiceForm = this.formBuilder.group({
      customerOrderId: ['', Validators.required],
      customerId: ['', Validators.required],
      invoiceType: ['', Validators.required],
      createdBy: ['', Validators.required],
      status: ['', Validators.required],
      dueDate: ['', Validators.required],
      paymentMethod: ['CASH', Validators.required],
      note: [''],
      totalDiscount: [0],
      tax: [0],
      InvoiceItems: this.formBuilder.array([
        this.invoiceItems()
      ])
    });
  }
  itemId(i: number): FormControl {
    return this.items.at(i).get('itemId') as FormControl;
  }
  quantity(i: number): FormControl {
    return this.items.at(i).get('quantity') as FormControl;
  }

  unitPrice(i: number): FormControl {
    return this.items.at(i).get('unitPrice') as FormControl;
  }

  get customerOrderId(): FormControl {
    return this.saleInvoiceForm.get('customerOrderId') as FormControl;
  }
  get customerId(): FormControl {
    return this.saleInvoiceForm.get('customerId') as FormControl;
  }

  get invoiceType(): FormControl {
    return this.saleInvoiceForm.get('invoiceType') as FormControl;
  }

  get createdBy(): FormControl {
    return this.saleInvoiceForm.get('createdBy') as FormControl;
  }

  get status(): FormControl {
    return this.saleInvoiceForm.get('status') as FormControl;
  }

  get dueDate(): FormControl {
    return this.saleInvoiceForm.get('dueDate') as FormControl;
  }

  get paymentMethod(): FormControl {
    return this.saleInvoiceForm.get('paymentMethod') as FormControl;
  }


  initializeForm(data: CustomerOrder) {
    this.saleInvoiceForm = this.formBuilder.group({
      customerOrderId: [(data.Id) ? data.Id : '', Validators.required],
      customerId: [data.ClientId, Validators.required],
      invoiceType: ['', Validators.required],
      createdBy: ['', Validators.required],
      dueDate: ['', Validators.required],
      paymentMethod: ['Check', Validators.required],
      note: [''],
      totalDiscount: [0],
      tax: [0],
      InvoiceItems: this.formBuilder.array([])
    });
    this.items.valueChanges
      .subscribe((value: any[]) => {
        this.discount = 0;
        this.totalQuantity = 0;
        this.totalBeforeTax = 0;
        this.totalAfterTax = 0;
        this.taxAmount = 0;
        value.forEach(element => {
          this.discount += element.discount;
          this.totalQuantity += element.quantity;
          this.totalBeforeTax += element.quantity * element.unitPrice;
        });


      });

    data.PurchaseOrderDetail.forEach(element => {
      this.items.push(this.formBuilder.group({
        customerOrderItemId: [element.Id, Validators.required],
        itemId: [element.ItemId, Validators.required],
        quantity: [element.Quantity, [Validators.required, Validators.min(element.Quantity)]],
        unitPrice: [element.PricePerItem, Validators.required],
        discount: [0],
        note: ['']
      }));
    });


  }

  onSubmit() {
    const data = this.saleInvoiceForm.value as Invoice;
    this.saleInvoiceApi.createCustomerOrderInvoice(this.orderId, data)
      .subscribe(
        (result: Invoice) => {
          alert('Invoice Created Successfuly');
          this.location.back();
        },
        this.handleError);
  }

  addItem() {
    this.items.push(this.invoiceItems());
  }

  removeItem(index: number) {
    this.items.removeAt(index);
  }


}
