import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import {
  EditSettingsModel, ToolbarItems, IEditCell, CommandModel,
  GridComponent, DialogEditEventArgs, SaveEventArgs
} from '@syncfusion/ej2-angular-grids';
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

  @ViewChild('grid')
  public grid: GridComponent;
  public data: Object[];
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public numericParams: IEditCell;
  public ddParams: IEditCell;
  public dpParams: IEditCell;
  public boolParams: IEditCell;
  public productValidation: Object;
  public quantityValidation: Object;
  public dueDateValidation: Object;
  public commands: CommandModel[];
  public productData: IEditCell;
  public employeeData: Object[];
  public idVisable: Boolean = false;
  private orderData: OrderModel;
  public orderForm: FormGroup;
  public pageSettings: Object;


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
    private formBuilder: FormBuilder) {

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
    return this.workOrderForm.get('orders') as FormArray;
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

    dm.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);
    this.workOrderApi.getAllProducts().subscribe(
      result => this.itemsList = result['Items']
    );

    this.data = [];

  }



  onSubmit() {
    const form = this.workOrderForm.value;
    console.log(form);
    const order = this.prepareFormData(form);
    console.log('ORDER');
    console.log(order);
    this.workOrderApi.addWorkOrder(order).subscribe(
      (success: WorkOrderView) => console.log(success),
      (error: HttpErrorResponse) => console.log(error)
    );
  }


  prepareFormData(form: any): WorkOrder {
  const order = new WorkOrder();
    order.orderedBy = form.orderedBy;
    order.description = form.description;
    form.orders.forEach(element => {
      order.workOrders.push({
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
