/*
 * @CreateTime: Nov 9, 2018 1:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 12:26 AM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Location } from '@angular/common';
import { Validators, FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { SaleOrderApiService } from '../sale-order-api.service';
import { Query, WebApiAdaptor, ReturnOption, DataManager } from '@syncfusion/ej2-data';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { SalesOrder } from '../../sales-data-model';
import { EmployeeApiService, Employee } from 'src/app/Modules/core/services/employees/employee-api.service';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { CustomerService } from 'src/app/Modules/core/services/customers/customer.service';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { Customer } from 'src/app/Modules/core/DataModels/customer-data.model';

@Component({
  selector: 'app-sale-order-form',
  templateUrl: './sale-order-form.component.html',
  styleUrls: ['./sale-order-form.component.css']
})
export class SaleOrderFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification') notification: NotificationComponent;
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

  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private salesOrderApi: SaleOrderApiService,
    private formBuilder: FormBuilder,
    private employeeApi: EmployeeApiService,
    private itemApi: ItemApiService,
    private customerApi: CustomerService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {

    super();
    this.createForm();
    this.today = new Date();
    this.customersQuery = new Query().select(['fullName', 'id']);
    this.customerFields = { text: 'fullName', value: 'id' };
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['name', 'id']);
    this.itemFields = { text: 'name', value: 'id' };

  }

  ngOnInit(): void {

    this.employeeApi.getAllEmployees().subscribe(
      (data: Employee[]) => this.employeesList = data
    );


    this.itemApi.getAllItems().subscribe(
      (data: ItemView[]) => this.itemsList = data,
      this.handleError
    );

    this.customerApi.getAllCustomers().subscribe(
      (data: Customer[]) => this.customersList = data,
      this.handleError
    );



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
        this.notification.showMessage('Customer order Created Successfuly');
        this.route.navigate([`../${co.Id}/booking`], { relativeTo: this.activatedRoute });

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
