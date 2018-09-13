import { Component, OnInit, ViewChild } from '@angular/core';
import { EditSettingsModel, ToolbarItems, IEditCell, CommandModel, GridComponent } from '@syncfusion/ej2-angular-grids';
import { EmployeeApiService } from '../../employee/employee-api.service';
import { WorkOrderAPIService } from '../work-order-api.service';
import { DataUtil } from '@syncfusion/ej2-data';
import { DropDownListComponent } from '@syncfusion/ej2-ng-dropdowns';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';

/**
* Reactive Forms Dialog template sample
*/
@Component({
  selector: 'app-work-order-form',
  templateUrl: './work-order-form.component.html',
  styleUrls: ['./work-order-form.component.css'],
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
  public productData: Object[];
  public employeeData: Object[];
  public fields: Object = { text: 'name', value: 'Id' };
  constructor(private employeeApi: EmployeeApiService, private workOrderApi: WorkOrderAPIService) {

  }
  ngOnInit(): void {
    this.data = [];
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add'];
    this.numericParams = { params: { decimals: 2, value: 5 } };
    this.ddParams = { params: { value: 'Germany' } };
    this.dpParams = { params: { value: new Date() } };
    this.productValidation = { required: false };
    this.quantityValidation = { required: false };
    this.employeeData = [{ name: 'Mike', Id: 2 }, { name: 'Ermias', id: 1 }];
    this.productData = DataUtil.distinct(['Mike', 'ermias'], 'itemId', true);
    this.dueDateValidation = { required: true };
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
    { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } },
    { type: 'Save', buttonOption: { cssClass: 'e-flat', iconCss: 'e-update e-icons' } },
    { type: 'Cancel', buttonOption: { cssClass: 'e-flat', iconCss: 'e-cancel-icon e-icons' } }];
  }

  submitt() {
    this.workOrderApi.addWorkOrder(this.data);
  }

}

