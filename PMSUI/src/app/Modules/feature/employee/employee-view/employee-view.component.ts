/*
 * @CreateTime: Sep 8, 2018 8:41 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 1, 2018 1:43 AM
 * @Description: Employee View Component class
 */

import { Component, OnInit, ViewChild } from '@angular/core';

import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { EmployeeApiService } from '../employee-api.service';
import {
  GridComponent, PageSettingsModel, SortSettingsModel,
  FilterSettingsModel, EditSettingsModel, ToolbarItems, CommandModel,
  RowSelectEventArgs
} from '@syncfusion/ej2-angular-grids';


@Component({
  selector: 'app-employee-view',
  templateUrl: './employee-view.component.html',
  styleUrls: ['./employee-view.component.css']
})

export class EmployeeViewComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  public data: DataManager;
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];

  constructor(private customerService: EmployeeApiService, private route: Router) { }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  customerViewColumns = [
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

  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/employees',
    updateUrl: 'http://localhost:5000/api/employees',
    insertUrl: 'http://localhost:5000/api/employees',
    removeUrl: 'http://localhost:5000/api/employees',
    adaptor: new WebApiAdaptor
  });

  ngOnInit(): void {

    this.data = this.dataManager;
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

  clickHandler(args: ClickEventArgs): void {

    if (args.item.id === 'employee_add') {

    } else if (args.item.id === 'employee_update') {
      console.log(args);
    } else if (args.item.id === 'employee_delete') {

    }
    if (args.item.id === 'expandall') {
      this.grid.groupModule.expandAll();
    }

    if (args.item.id === 'collapseall') {
      this.grid.groupModule.collapseAll();
    }
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


