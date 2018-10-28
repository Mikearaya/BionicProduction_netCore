import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';
import { DataManager, WebApiAdaptor, Query, ReturnOption } from '@syncfusion/ej2-data';
import { ActivatedRoute } from '@angular/router';
import { SalesOrder } from '../../sales/sale-order-api.service';
import { CustomErrorResponse } from '../../../core/core-api.service';
import { CustomerOrder } from '../../../core/DataModels/customer-order-data-models';
import { Invoice } from '../sales-invoice-data-model';

@Component({
  selector: 'app-sale-invoice-form',
  templateUrl: './sale-invoice-form.component.html',
  styleUrls: ['./sale-invoice-form.component.css']
})

export class SaleInvoiceFormComponent implements OnInit {
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

  private customerOrderId: number;
  private invoiceId: number;


  constructor(private formBuilder: FormBuilder,
    private saleInvoiceApi: SaleInvoiceApiService,
    private activatedRoute: ActivatedRoute,
    @Inject('EMPLOYEE_API_URL') private employeeApiUrl: string,
    @Inject('BASE_URL') private apiUrl: string) {

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
    this.customerOrderId = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');

    // TODO: Define invoice update functionality
    this.invoiceId = + this.activatedRoute.snapshot.paramMap.get('invoiceId');

    if (this.customerOrderId) {
      this.saleInvoiceApi.getCustomerOrder(this.customerOrderId).subscribe((data: CustomerOrder) => this.initializeForm(data),
        (error: CustomErrorResponse) => console.log(error));
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
    const dm: DataManager = new DataManager(
      { url: this.employeeApiUrl, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    const itemDm: DataManager = new DataManager(
      { url: `${this.apiUrl}/products`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    const customerDm: DataManager = new DataManager(
      { url: `${this.apiUrl}/customers`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    const customerOrderDm: DataManager = new DataManager(
      { url: `${this.apiUrl}/salesorders`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    customerOrderDm.ready.then((e: ReturnOption) => this.customerOrdersList = <Object[]>e.result).catch((e) => true);

    customerDm.ready.then((e: ReturnOption) => this.customersList = <Object[]>e.result).catch((e) => true);
    itemDm.ready.then((e: ReturnOption) => this.itemsList = <Object[]>e.result).catch((e) => true);
    dm.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);

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
      subTotal: [0],
      note: ['']
    });
  }

  createForm() {
    this.saleInvoiceForm = this.formBuilder.group({
      customerOrderId: [''],
      customerId: ['', Validators.required],
      invoiceType: ['', Validators.required],
      createdBy: ['', Validators.required],
      status: ['', Validators.required],
      dateAdded: ['', Validators.required],
      dueDate: ['', Validators.required],
      currencyId: [{ value : '', disabled: true}],
      note: [''],
      totalDiscount: [0],
      tax: [0],
      InvoiceItems: this.formBuilder.array([
        this.invoiceItems()
      ])
    });
  }

  initializeForm(data: CustomerOrder) {
    this.saleInvoiceForm = this.formBuilder.group({
      customerOrderId: data.Id,
      customerId: [data.ClientId, Validators.required],
      invoiceType: ['', Validators.required],
      createdBy: ['', Validators.required],
      status: ['', Validators.required],
      dateAdded: ['', Validators.required],
      dueDate: ['', Validators.required],
      currencyId: [{ value : '', disabled: true}],
      note: [''],
      totalDiscount: [0],
      tax: [0],
      InvoiceItems: this.formBuilder.array([ ])
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
        subTotal: [0],
        note: ['']
      }));
    });


  }

  onSubmit() {
    const data = this.saleInvoiceForm.value as Invoice;
    this.saleInvoiceApi.createCustomerOrderInvoice(this.customerOrderId, data)
                                                    .subscribe(
                                                    (result: Invoice) => alert('Invoice Created Successfuly'),
                                                    (error: CustomErrorResponse) => console.log(error));
  }

  addItem() {
    this.items.push(this.invoiceItems());
  }

  removeItem(index: number) {
    this.items.removeAt(index);
  }


}
