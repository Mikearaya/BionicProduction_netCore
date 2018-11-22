import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';
import { DataManager, WebApiAdaptor, Query, ReturnOption } from '@syncfusion/ej2-data';
import { ActivatedRoute } from '@angular/router';

import { CustomerOrder } from '../../../core/DataModels/customer-order-data-models';
import { Invoice } from '../sales-invoice-data-model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Location } from '@angular/common';
import { CustomerOrderGetterApiService } from 'src/app/Modules/core/services/customer-order/customer-order-getter-api.service';
import { FormValidators } from '@syncfusion/ej2-angular-inputs';

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
  public invoice: Invoice;
  public isUpdate: Boolean;


  constructor(private formBuilder: FormBuilder,
    private saleInvoiceApi: SaleInvoiceApiService,
    private customerOrderGetter: CustomerOrderGetterApiService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    @Inject('EMPLOYEE_API_URL') private employeeApiUrl: string,
    @Inject('BASE_URL') private apiUrl: string) {

    super();

    this.isUpdate = false;

    this.createForm();
    this.customersQuery = new Query().select(['firstName', 'id']);
    this.customerFields = { text: 'firstName', value: 'id' };
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['name', 'id']);
    this.itemFields = { text: 'name', value: 'id' };
    this.customerOrderQuery = new Query().select(['customerName', 'id']);
    this.customerOrderFields = { text: 'id', value: 'id' };
  }

  ngOnInit() {
    this.orderId = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');
    this.invoiceId = + this.activatedRoute.snapshot.paramMap.get('invoiceId');

    if (this.orderId) {
      this.customerOrderGetter.getCustomerOrder(this.orderId).subscribe(
        (data: CustomerOrder) => this.initializeForm(data),
        this.handleError
      );
    }

    if (this.invoiceId) {
      this.isUpdate = true;
      this.saleInvoiceApi.getInvoiceById(this.invoiceId).subscribe(
        (data) => this.invoice = data,
        this.handleError
      );
    }
    this.items.valueChanges
      .subscribe((data: any[]) => { this.calculatePrice(data); });

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
      itemId: ['', FormValidators.required],
      quantity: [0, FormValidators.required],
      unitPrice: [0, FormValidators.required],
      discount: [0],
      note: ['']
    });
  }

  createForm() {
    this.saleInvoiceForm = this.formBuilder.group({
      customerOrderId: ['', FormValidators.required],
      customerId: ['', FormValidators.required],
      invoiceType: ['', FormValidators.required],
      createdBy: ['', FormValidators.required],
      status: ['', FormValidators.required],
      dueDate: ['', FormValidators.required],
      paymentMethod: ['CASH', FormValidators.required],
      note: [''],
      totalDiscount: [0],
      tax: [0],
      InvoiceItems: this.formBuilder.array([
        this.invoiceItems()
      ])
    });
    this.tax.valueChanges.subscribe(_ => this.calculatePrice([]));
    this.totaldiscount.valueChanges.subscribe(_ => this.calculatePrice([]));
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

  discounts(i: number): FormControl {
    return this.items.at(i).get('discount') as FormControl;
  }

  get totaldiscount(): FormControl {
    return this.saleInvoiceForm.get('totalDiscount') as FormControl;
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

  get tax(): FormControl {
    return this.saleInvoiceForm.get('tax') as FormControl;
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
      customerOrderId: [data.Id ? data.Id : '', Validators.required],
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
        this.calculatePrice(value);
      });

    data.PurchaseOrderDetail.forEach(element => {
      this.items.push(this.formBuilder.group({
        customerOrderItemId: [element.Id, Validators.required],
        itemId: [element.ItemId, Validators.required],
        quantity: [element.Quantity, [Validators.required]],
        unitPrice: [element.PricePerItem, Validators.required],
        discount: [0],
        note: ['']
      }));
    });

    this.tax.valueChanges.subscribe(_ => this.calculatePrice([]));
    this.totaldiscount.valueChanges.subscribe(_ => this.calculatePrice([]));


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

  private calculatePrice(value: any[] = []): void {

    this.discount = 0;
    this.totalQuantity = 0;
    this.totalBeforeTax = 0;
    this.totalAfterTax = 0;
    this.taxAmount = 0;
    this.items.controls.forEach(element => {
      this.discount += element.value.discount;
      this.totalQuantity += element.value.quantity;
      this.totalBeforeTax += ((element.value.quantity * element.value.unitPrice) -
        (element.value.quantity * element.value.unitPrice) * (element.value.discount / 100));
    });

    this.totalBeforeTax = this.totalBeforeTax - this.totalBeforeTax * (this.totaldiscount.value as number / 100);
    this.totalAfterTax = this.totalBeforeTax - (this.totalBeforeTax * (this.tax.value / 100));
  }
}
