/*
 * @CreateTime: Sep 8, 2018 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 12:23 AM
 * @Description: Employee View Component class
 */

import { Component, OnInit, ViewChild, Inject } from '@angular/core';

import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router, ActivatedRoute } from '@angular/router';
import {
  GridComponent, PageSettingsModel, SortSettingsModel,
  FilterSettingsModel, EditSettingsModel, ToolbarItems, CommandModel,
  RowSelectEventArgs
} from '@syncfusion/ej2-angular-grids';
import { EmployeeApiService, Employee } from 'src/app/Modules/core/services/employees/employee-api.service';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';


@Component({
  selector: 'app-employee-view',
  templateUrl: './employee-view.component.html',
  styleUrls: ['./employee-view.component.css']
})

export class EmployeeViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  public data: Employee[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public customerViewColumns = [
    { key: 'id', humanReadable: 'ID', primaryKey: true, editable: false, isIdentity: true },
    {
      key: 'firstName', humanReadable: 'First Name', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity: false
    },
    {
      key: 'lastName', humanReadable: 'Last Name', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity: false
    }
  ];


  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private employeeApi: EmployeeApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router) {
    super();
  }


  public dataManager: DataManager = new DataManager({
    url: `${this.apiUrl}/employees`,
    updateUrl: `${this.apiUrl}/employees`,
    insertUrl: `${this.apiUrl}/employees`,
    removeUrl: `${this.apiUrl}/employees`,
    adaptor: new WebApiAdaptor
  });

  ngOnInit(): void {

    this.employeeApi.getAllEmployees().subscribe(
      (data: Employee[]) => this.data = data,
      this.handleError
    );

    this.pageSettings = { pageSize: 6 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel', 'Print', 'Search', 'ExcelExport', 'ColumnChooser'];
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
    { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
    //   alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
  }



  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'employee_excelexport') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
      this.grid.excelExport();
    }
    if (args.item.id === 'employee_pdfexport') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
      this.grid.pdfExport();
    }
  }

}


