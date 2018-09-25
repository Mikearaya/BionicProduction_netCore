import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { SaleOrderApiService } from '../sale-order-api.service';
import { Query, WebApiAdaptor, ReturnOption, DataManager } from '@syncfusion/ej2-data';

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
    private formBuilder: FormBuilder) {

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
      description: ['', Validators.required],
      orders: this.formBuilder.array([
        this.formBuilder.group({
          itemId: ['', Validators.required],
          quantity: ['', [Validators.required, Validators.min(0)]],
          dueDate: [new Date(), Validators.required]
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
      quantity: ['', Validators.required],
      dueDate: [new Date(), Validators.required]
    }));
  }
  ngOnInit(): void {

    const dm: DataManager = new DataManager(
      { url: 'http://localhost:5000/api/employees', adaptor: new WebApiAdaptor, offline: true },
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
    console.log('ORDER');

   /* this.workOrderApi.addWorkOrder(order).subscribe(
      (success: WorkOrderView) => console.log(success),
      (error: HttpErrorResponse) => console.log(error)
    );*/
  }


  prepareFormData(form: any): SalesOrder {
  const order = new SalesOrder();
    order.orderedBy = form.orderedBy;
    order.description = form.description;
    form.orders.forEach(element => {
      order.saleOrderList.push({
        itemId : element.itemId,
        quantity : element.quantity,
        dueDate : element.dueDate
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

export class SalesOrder {
  id?: number;
  orderedBy: number;
  customerId: number;
  description: number;
  paymentMethod: string;
  saleOrderList: SaleOrderDetail[] = [];
}

export class SaleOrderDetail {
  id?: number;
  itemId: number;
  quantity: number;
  dueDate: Date;
}
