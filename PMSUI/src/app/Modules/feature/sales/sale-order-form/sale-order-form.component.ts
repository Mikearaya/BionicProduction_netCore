import { Component, OnInit, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { SaleOrderApiService } from '../sale-order-api.service';
import { Query, WebApiAdaptor, ReturnOption, DataManager } from '@syncfusion/ej2-data';
import { HttpErrorResponse } from '@angular/common/http';
import { SalesOrder } from '../sales-data-model';

@Component({
  selector: 'app-sale-order-form',
  templateUrl: './sale-order-form.component.html',
  styleUrls: ['./sale-order-form.component.css']
})
export class SaleOrderFormComponent implements OnInit {

  public idVisable: Boolean = false;
  private orderData: SalesOrder;
  public salesOrderForm: FormGroup;



  public itemId: FormControl;


  public employeeQuery: Query;
  public employeeFields: Object;


  public customersQuery: Query;
  public customerFields: Object;

  public itemQuery: Query;
  public itemFields: Object;

  public itemsList: any[];
  public employeesList: any[];
  public customersList: any[];
  public today: Date;

  constructor(private salesOrderApi: SaleOrderApiService,
    private formBuilder: FormBuilder,
    private location: Location,
    @Inject('EMPLOYEE_API_URL') private employeeApiUrl: string) {

    this.createForm();
    this.today = new Date();
    this.customersQuery = new Query().select(['firstName', 'id']);
    this.customerFields = { text: 'firstName', value: 'id' };
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['code', 'id']);
    this.itemFields = { text: 'code', value: 'id' };

  }

  createForm(): void {
    this.salesOrderForm = this.formBuilder.group({
      orderedBy: ['', Validators.required],
      client: ['', Validators.required],
      paymentMethod: ['Check', Validators.required],
      initialPayment: [0],
      title: ['', Validators.required],
      description: ['', Validators.required],
      orders: this.formBuilder.array([
        this.formBuilder.group({
          itemId: ['', Validators.required],
          unitPrice: [0, [Validators.required, Validators.min(0)]],
          quantity: [1, [Validators.required, Validators.min(1)]],
          dueDate: ['', Validators.required]
        })
      ])
    });
  }
  get orders() {
    return this.salesOrderForm.get('orders') as FormArray;
  }

  addOrder() {
    this.orders.push(this.formBuilder.group({
      itemId: ['', Validators.required],
      unitPrice: [0, [Validators.required, Validators.min(0)]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      dueDate: ['', Validators.required]
    }));
  }
  ngOnInit(): void {

    const dm: DataManager = new DataManager(
      { url: this.employeeApiUrl, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    const itemDm: DataManager = new DataManager(
      { url: 'http://localhost:5000/api/products', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    const customerDm: DataManager = new DataManager(
      { url: 'http://localhost:5000/api/customers', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    customerDm.ready.then((e: ReturnOption) => this.customersList = <Object[]>e.result).catch((e) => true);
    itemDm.ready.then((e: ReturnOption) => this.itemsList = <Object[]>e.result).catch((e) => true);
    dm.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);



  }



  onSubmit() {
    const form = this.salesOrderForm.value;
    const order = this.prepareFormData(form);


    this.salesOrderApi.createSalesOrder(order).subscribe(
      (success: SalesOrder) => {
        this.location.back();
        alert('Customer order added Successfuly');
      },
      (error: HttpErrorResponse) => console.log(error)
    );
  }


  prepareFormData(form: any): SalesOrder {
    const order = new SalesOrder();
    order.createdBy = form.orderedBy;
    order.clientId = form.client;
    order.title = form.title;
    order.description = form.description;
    form.orders.forEach(element => {
      order.PurchaseOrderDetail.push({
        itemId: element.itemId,
        quantity: element.quantity,
        dueDate: element.dueDate,
        unitPrice: element.unitPrice
      });
    });

    return order;
  }

  dateValidator() {
    return (control: FormControl): null | Object => {
      return control.value !== null && (1900 <= control.value.getFullYear() &&
        control.value.getFullYear() <= 2099)
        ? null : { OrderDate: { value: control.value } };
    };
  }


}
