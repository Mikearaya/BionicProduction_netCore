import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import {
  EditSettingsModel, ToolbarItems, IEditCell, CommandModel,
  GridComponent, DialogEditEventArgs, SaveEventArgs
} from '@syncfusion/ej2-angular-grids';
import { WorkOrderAPIService } from '../work-order-api.service';
import { FormGroup, Validators, FormControl, AbstractControl, FormBuilder, FormArray } from '@angular/forms';
import { Browser } from '@syncfusion/ej2-base';
import { UrlAdaptor, DataManager, Query, ODataAdaptor, ReturnOption, WebApiAdaptor } from '@syncfusion/ej2-data';


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
  public fields: Object = { text: 'name', value: 'Id' };
  public idVisable: Boolean = false;
  private orderData: OrderModel;
  public orderForm: FormGroup;
  public pageSettings: Object;


  public itemId: FormControl;
  public workOrderForm: FormGroup;

  public employeeQuery: Query = new Query().select(['firstName', 'id']);
  public employeeFields: Object = { text: 'firstName', value: 'id' };

  public itemQuery: Query = new Query().select(['code', 'id']);
  public itemFields: Object = { text: 'code', value: 'id' };

  public itemsList: any[];
  public employeesList: any[];

  constructor(private workOrderApi: WorkOrderAPIService,
    private formBuilder: FormBuilder) {

    this.createForm();

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
  }

  dateValidator() {
    return (control: FormControl): null | Object => {
      return control.value !== null && (1900 <= control.value.getFullYear() &&
        control.value.getFullYear() <= 2099)
        ? null : { OrderDate: { value: control.value } };
    };
  }



}

export interface IOrderModel {
  OrderID?: number;
  CustomerName?: string;
  ShipCity?: string;
  OrderDate?: Date;
  Freight?: number;
  ShipCountry?: string;
  ShipAddress?: string;
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
