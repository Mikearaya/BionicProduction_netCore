import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Location} from '@angular/common';
import {
  CommandModel
} from '@syncfusion/ej2-ng-grids';
import { WorkOrderAPIService, WorkOrder, WorkOrderView } from '../work-order-api.service';
import { FormGroup, Validators, FormControl, AbstractControl, FormBuilder, FormArray } from '@angular/forms';
import { Browser } from '@syncfusion/ej2-base';
import { UrlAdaptor, DataManager, Query, ODataAdaptor, ReturnOption, WebApiAdaptor } from '@syncfusion/ej2-data';
import { HttpErrorResponse } from '@angular/common/http';


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
  private orderData: OrderModel;
  public orderForm: FormGroup;



  public itemId: FormControl;
  public workOrderForm: FormGroup;

  public employeeQuery: Query;
  public employeeFields: Object;

  public itemQuery: Query;
  public itemFields: Object;

  public itemsList: any[];
  public employeesList: any[];
  public today: Date;

  constructor(private workOrderApi: WorkOrderAPIService,
    private formBuilder: FormBuilder,
    private location: Location) {

    this.createForm();
    this.today = new Date();
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.itemQuery = new Query().select(['code', 'id']);
    this.itemFields = { text: 'code', value: 'id' };

  }

  createForm(): void {
    this.workOrderForm = this.formBuilder.group({
      orderedBy: ['', Validators.required],
      description: [''],
        itemId: ['', Validators.required],
          quantity: ['', [Validators.required, Validators.min(0)]],
          dueDate: ['', Validators.required],
          startDate: ['', Validators.required]
    });
  }


  ngOnInit(): void {

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
    this.workOrderApi.addWorkOrder(order).subscribe(
      (success: WorkOrderView) => {
        this.location.back();
        alert('Work Order Created Successfully');


      },
      (error: HttpErrorResponse) => console.log(error)
    );
  }


  prepareFormData(form: any): WorkOrder {
    const order: WorkOrder = {
      itemId : form.itemId,
      quantity: form.quantity,
      dueDate: form.dueDate,
      start: form.startDate,
      orderedBy : form.orderedBy,
    description : form.description
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

export class OrderModel {
  id?: number;
  description: string;
  orderedBy: number = null;
  workOrderItems: OrderDetail[] = [];
}

class OrderDetail {
  orderId?: number;
  itemId: number;
  quantity: number;
  dueDate: string;
}
