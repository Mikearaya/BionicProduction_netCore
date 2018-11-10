/*
 * @CreateTime: Nov 9, 2018 1:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 9, 2018 2:19 AM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, Inject } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { SaleOrderApiService } from '../sale-order-api.service';
import { Query, WebApiAdaptor, ReturnOption, DataManager } from '@syncfusion/ej2-data';
import { HttpErrorResponse } from '@angular/common/http';
import { SalesOrder } from '../sales-data-model';
import { Router } from '@angular/router';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-sale-order-form',
  templateUrl: './sale-order-form.component.html',
  styleUrls: ['./sale-order-form.component.css']
})
export class SaleOrderFormComponent extends CommonProperties implements OnInit {

  public idVisable: Boolean = false;
  private orderData: SalesOrder;
  public salesOrderForm: FormGroup;
  public itemId: FormControl;
  public errors: Object[] = [];
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
  public orderStatus = ['Quotation', 'Waiting for Confirmation', 'Confirmed', 'Canceled', 'Delivered'];
  public errorDescription: any;

  constructor(private salesOrderApi: SaleOrderApiService,
    private formBuilder: FormBuilder,
    private location: Location,
    private route: Router,
    @Inject('EMPLOYEE_API_URL') private employeeApiUrl: string
  ) {

    super();
    this.createForm();
    this.today = new Date();
    this.customersQuery = new Query().select(['firstName', 'id']);
    this.customerFields = { text: 'firstName', value: 'id' };
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['name', 'id']);
    this.itemFields = { text: 'name', value: 'id' };

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

  createForm(): void {
    this.salesOrderForm = this.formBuilder.group({
      orderedBy: ['', Validators.required],
      client: ['', Validators.required],
      deliveryDate: ['', Validators.required],
      status: ['Quotation', Validators.required],
      description: [''],
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

  get orderedBy(): FormControl {
    return this.salesOrderForm.get('orderedBy') as FormControl;
  }

  get deliveryDate(): FormControl {
    return this.salesOrderForm.get('deliveryDate') as FormControl;
  }

  get status(): FormControl {
    return this.salesOrderForm.get('status') as FormControl;
  }

  get client(): FormControl {
    return this.salesOrderForm.get('orderedBy') as FormControl;
  }
  get orders(): FormArray {
    return this.salesOrderForm.get('orders') as FormArray;
  }

  addOrder() {
    this.orders.push(this.formBuilder.group({
      itemId: ['', Validators.required],
      unitPrice: [0, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(0)]],
      dueDate: ['', Validators.required]
    }));
  }




  onSubmit() {
    const form = this.salesOrderForm.value;
    const order = this.prepareFormData(form);


    this.salesOrderApi.createSalesOrder(order).subscribe(
      (co: SalesOrder) => {
        alert('Customer order added Successfuly');
        this.route.navigate([`sales/${co.Id}/booking`]);

      },
      this.handleError
    );
  }


  prepareFormData(form: any): SalesOrder {
    const order = new SalesOrder();
    order.createdBy = (form.orderedBy) ? form.orderedBy : null;
    order.clientId = (form.client) ? form.client : null;
    order.description = form.description;
    order.status = form.status;
    order.deliveryDate = form.deliveryDate;
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


}
