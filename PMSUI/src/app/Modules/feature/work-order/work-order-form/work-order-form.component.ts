/*
 * @CreateTime: Nov 26, 2018 4:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 26, 2018 10:23 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewEncapsulation, Inject, ViewChild } from '@angular/core';
import { Location } from '@angular/common';
import {
  CommandModel
} from '@syncfusion/ej2-angular-grids';
import { WorkOrderAPIService, WorkOrder, WorkOrderView, OrderModel } from '../work-order-api.service';
import { FormGroup, Validators, FormControl, FormBuilder } from '@angular/forms';
import { DataManager, Query, ReturnOption, WebApiAdaptor } from '@syncfusion/ej2-data';
import { ActivatedRoute } from '@angular/router';
import { ProductGetterService } from '../../../core/services/product-getter.service';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';


@Component({
  selector: 'app-work-order-form',
  templateUrl: './work-order-form.component.html',
  styleUrls: ['./work-order-form.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class WorkOrderFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  private notification: NotificationComponent;

  public commands: CommandModel[];
  public employeeData: Object[];
  public idVisable: Boolean = false;
  public orderData: OrderModel;
  public orderForm: FormGroup;
  public manufactureOrderId: number;
  public customerOrderId: number;
  public isUpdate: Boolean = false;
  public isFromCustomerOrder: Boolean = false;
  public isFromItem: Boolean = false;
  public workOrderForm: FormGroup;
  public employeeQuery: Query;
  public employeeFields: Object;
  public itemQuery: Query;
  public itemFields: Object;
  public itemsList: any[];
  public employeesList: any[];
  public today: Date;
  private itemId: number;

  constructor(private workOrderApi: WorkOrderAPIService,
    @Inject('BASE_URL') private apiUrl: string,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private productApiService: ProductGetterService) {
    super();

    this.createForm();
    this.today = new Date();
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['name', 'id']);
    this.itemFields = { text: 'name', value: 'id' };
    this.orderData = new OrderModel();

  }

  createForm(data: OrderModel = null): void {
    this.workOrderForm = this.formBuilder.group({
      orderedBy: [(data) ? data.orderedById : '', Validators.required],
      description: [(data) ? data.description : ''],
      itemId: [(data) ? data.productId : '', Validators.required],
      quantity: [(data) ? data.quantity : '', [Validators.required]],
      dueDate: [(data) ? data.dueDate : '', Validators.required],
      startDate: [(data) ? data.start : '', Validators.required],
      salesOrderItemId: [(data) ? data.salesOrderItemId : '']
    });
  }

  createItemForm(data: number): void {
    this.workOrderForm = this.formBuilder.group({
      orderedBy: ['', Validators.required],
      description: [''],
      itemId: [data, Validators.required],
      quantity: ['', [Validators.required]],
      dueDate: ['', Validators.required],
      startDate: ['', Validators.required],
      salesOrderItemId: ['']
    });
  }


  ngOnInit(): void {

    this.manufactureOrderId = + this.activatedRoute.snapshot.paramMap.get('workOrderId');
    this.customerOrderId = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');
    this.itemId = + this.activatedRoute.snapshot.paramMap.get('itemId');

    if (this.manufactureOrderId) {
      this.isUpdate = true;
      this.workOrderApi.getWorkOrderById(this.manufactureOrderId)
        .subscribe((data: OrderModel) => {
          this.orderData = data;
          this.createForm(data);
        },
          (error: CustomErrorResponse) => console.log(error)
        );
    } else if (this.customerOrderId) {
      this.isFromCustomerOrder = true;
      this.workOrderApi.getWorkOrderRequestById(this.customerOrderId)
        .subscribe((data: OrderModel) => {
          this.orderData = data;
          this.createForm(data);
        },
          (error: CustomErrorResponse) => console.log(error)
        );
    } else if (this.itemId) {
      this.isFromItem = true;
      this.productApiService.getCriticalProductById(this.itemId)
        .subscribe((data: any) => {
          this.orderData.productId = data.id;
          this.orderData.product = data.product;
          this.orderData.productName = data.productName;
          this.orderData.quantity = data.required;
          this.createForm(this.orderData);
        },
          (error: CustomErrorResponse) => console.log(error)
        );
    }

    const dm: DataManager = new DataManager(
      { url: `${this.apiUrl}/employees`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    dm.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);

    this.workOrderApi.getAllProducts().subscribe(
      result => this.itemsList = result['Items']
    );


  }



  onSubmit() {
    const form = this.workOrderForm.value;
    const order = this.prepareFormData(form);
    if (this.isUpdate) {
      order.id = this.manufactureOrderId;
      this.workOrderApi.updateWorkOrder(this.manufactureOrderId, order)
        .subscribe((success: boolean) => {
          this.notification.showMessage('Manufacture order updated Successfuly');
          this.location.back();
        },
          this.handleError
        );
    } else {

      this.workOrderApi.addWorkOrder(order).subscribe(
        (success: WorkOrderView) => {
          this.notification.showMessage('Manufacture order created Successfuly');
          this.location.back();
        },
        this.handleError
      );
    }
  }


  prepareFormData(form: any): WorkOrder {
    const order: WorkOrder = {
      itemId: form.itemId,
      quantity: form.quantity,
      dueDate: form.dueDate,
      start: form.startDate,
      orderedBy: form.orderedBy,
      description: form.description,
      purchaseOrderItemId: (form.salesOrderItemId) ? form.salesOrderItemId : 0,
    };

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

