import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Location } from '@angular/common';
import {
  CommandModel
} from '@syncfusion/ej2-ng-grids';
import { WorkOrderAPIService, WorkOrder, WorkOrderView, OrderModel } from '../work-order-api.service';
import { FormGroup, Validators, FormControl, AbstractControl, FormBuilder, FormArray } from '@angular/forms';
import { Browser } from '@syncfusion/ej2-base';
import { UrlAdaptor, DataManager, Query, ReturnOption, WebApiAdaptor } from '@syncfusion/ej2-data';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { CustomErrorResponse } from '../../../core/core-api.service';
import { ProductGetterService } from '../../../core/services/product-getter.service';


@Component({
  selector: 'app-work-order-form',
  templateUrl: './work-order-form.component.html',
  styleUrls: ['./work-order-form.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class WorkOrderFormComponent implements OnInit {

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
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private productApiService: ProductGetterService) {

    this.createForm();
    this.today = new Date();
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['name', 'id']);
    this.itemFields = { text: 'name', value: 'id' };
    this.orderData = new OrderModel();

  }

  createForm(data: OrderModel = null ): void {
    console.log(data);
    this.workOrderForm = this.formBuilder.group({
      orderedBy: [(data) ? data.orderedById : '', Validators.required],
      description: [(data) ? data.description : ''],
      itemId: [(data) ? data.productId : '', Validators.required],
      quantity: [(data) ? data.quantity : '', [Validators.required, Validators.min(0)]],
      dueDate: [(data) ? data.dueDate : '', Validators.required],
      startDate: [(data) ? data.start : '', Validators.required],
      salesOrderItemId: [(data) ? data.salesOrderItemId : '']
    });
  }

  createItemForm(data: number ): void {
    console.log(data);
    this.workOrderForm = this.formBuilder.group({
      orderedBy: ['', Validators.required],
      description: [''],
      itemId: [ data, Validators.required],
      quantity: ['', [Validators.required, Validators.min(0)]],
      dueDate: [ '', Validators.required],
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
      { url: 'http://localhost:5000/api/employees', adaptor: new WebApiAdaptor, offline: true },
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
          this.location.back();
          alert('Work Order Created Successfully');

        },
          (error: HttpErrorResponse) => console.log(error)
        );
    } else {

      this.workOrderApi.addWorkOrder(order).subscribe(
        (success: WorkOrderView) => {
          this.location.back();
          alert('Work Order Created Successfully');


        },
        (error: HttpErrorResponse) => console.log(error)
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

