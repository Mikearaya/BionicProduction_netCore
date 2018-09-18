import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import {
  EditSettingsModel, ToolbarItems, IEditCell, CommandModel,
  GridComponent, DialogEditEventArgs, SaveEventArgs
} from '@syncfusion/ej2-angular-grids';
import { WorkOrderAPIService } from '../work-order-api.service';
import { DataUtil } from '@syncfusion/ej2-data';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { Browser } from '@syncfusion/ej2-base';
import { Dialog } from '@syncfusion/ej2-popups';

/**
* Reactive Forms Dialog template sample
*/
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
  public shipCityDistinctData: Object[];
  public shipCountryDistinctData: Object[];
  constructor(private workOrderApi: WorkOrderAPIService) {

    this.orderData = new OrderModel();

  }
  ngOnInit(): void {
    this.shipCityDistinctData = ['Addis Ababa', 'Nazret'];
    this.shipCountryDistinctData = ['Ethiopia', 'Kenya'];
    this.data = [];
    this.productData = { params: { value: 'Germany' } };
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add'];
    this.numericParams = { params: { decimals: 2, value: 5 } };
    this.ddParams = { params: { value: 'Germany' } };
    this.dpParams = { params: { value: new Date() } };
    this.productValidation = { required: true };
    this.quantityValidation = { required: true };
    this.employeeData = [{ name: 'Mike', Id: 2 }, { name: 'Ermias', id: 1 }];
    this.dueDateValidation = { required: true };
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
    { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } },
    { type: 'Save', buttonOption: { cssClass: 'e-flat', iconCss: 'e-update e-icons' } },
    { type: 'Cancel', buttonOption: { cssClass: 'e-flat', iconCss: 'e-cancel-icon e-icons' } }];
  }

  submitt() {
    alert('hello');
    this.workOrderApi.addWorkOrder(this.data).subscribe(result => console.log(result));
  }

  createFormGroup(data: IOrderModel): FormGroup {
    return new FormGroup({
      OrderID: new FormControl(data.OrderID, Validators.required)
      , OrderDate: new FormControl(data.OrderDate, this.dateValidator()),
      CustomerName: new FormControl(data.CustomerName, Validators.required),
      Freight: new FormControl(data.Freight),
      ShipAddress: new FormControl(data.ShipAddress),
      ShipCity: new FormControl(data.ShipCity),
      ShipCountry: new FormControl(data.ShipCountry)
    });
  }

  dateValidator() {
    return (control: FormControl): null | Object => {
      return control.value !== null && (1900 <= control.value.getFullYear() &&
        control.value.getFullYear() <= 2099)
        ? null : { OrderDate: { value: control.value } };
    };
  }

  actionBegin(args: SaveEventArgs): void {
    this.productData = { params: { value: 'Germany' } };
    console.log('order begin');
    console.log(args);

    if (args.requestType === 'beginEdit' || args.requestType === 'add') {
    }

    if (args.requestType === 'save') {
const detail = new OrderDetail();
      detail.itemId = args.data['itemId'];
      detail.quantity = args.data['quantity'];
      detail.dueDate = (<Date>args.data['dueDate']).toISOString();
      console.log(detail);
      this.orderData.workOrderItems.push(detail);
      this.orderData.orderedBy = 1;
      this.orderData.description = 'described';
      console.log(this.orderData);
this.workOrderApi.addWorkOrder(this.orderData).subscribe(result => console.log(result));
    }
  }

  actionComplete(args: DialogEditEventArgs): void {

    if ((args.requestType === 'beginEdit' || args.requestType === 'add')) {
      if (Browser.isDevice) {
      }
      // Set initail Focus
      if (args.requestType === 'beginEdit') {
      } else if (args.requestType === 'add') {
      }
    }
  }

  get OrderID(): AbstractControl { return this.orderForm.get('OrderID'); }
  get CustomerName(): AbstractControl { return this.orderForm.get('CustomerName'); }


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
