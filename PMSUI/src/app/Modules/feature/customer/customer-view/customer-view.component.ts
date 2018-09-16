/*
 * @CreateTime: Sep 5, 2018 8:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 8:51 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  EditSettingsModel, CommandModel, RowSelectEventArgs
} from '@syncfusion/ej2-grids';
import { CustomerService, Customer } from '../../customer/customer.service';
import { WebApiAdaptor, DataManager, UrlAdaptor } from '@syncfusion/ej2-data';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Route, Router } from '@angular/router';


@Component({
  selector: 'app-data-grid',
  templateUrl: './customer-view.component.html'
})
export class CustomerViewComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  public data: DataManager;
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];

      constructor(
                  private customerService: CustomerService,
                  private route: Router ) {

      }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  customerViewColumns = [
    { key: 'id', humanReadable: 'ID', primaryKey: true, editable: false, isIdentity : true },
    {
      key: 'firstName', humanReadable: 'First Name', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity : false
    },
    {
      key: 'lastName', humanReadable: 'Last Name', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity : false
    },
    {
      key: 'mainPhone', humanReadable: 'Telephone', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity : false
    },
    {
      key: 'type', humanReadable: 'Type', primaryKey: false, editable: true, dataType: 'dropdownedit',
      validationRule: { required: true }, isIdentity : false
    },
    {
      key: 'tin', humanReadable: 'TIN No.', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true, minLength: 10, maxLength: 10 }, isIdentity : false
    },
    { key: 'email', humanReadable: 'E-Mail', primaryKey: false, editable: true, dataType: 'TextBox', isIdentity : false }
  ];
  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/customers',
    updateUrl: 'http://localhost:5000/api/customers',
    insertUrl: 'http://localhost:5000/api/customers',
    removeUrl: 'http://localhost:5000/api/customers',
    adaptor: new WebApiAdaptor
  });
  ngOnInit(): void {
    this.data = this.dataManager;

    this.pageSettings = { pageSize: 6 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel', 'Print', 'Search', 'ExcelExport', 'ColumnChooser'];
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
        { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
   // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
}

  clickHandler(args: ClickEventArgs): void {

    if (args.item.id === 'customer_add') {

    } else if (args.item.id === 'customer_update') {
      // console.log(args);
    } else if (args.item.id === 'customer_delete') {

    }
    if (args.item.id === 'expandall') {
      this.grid.groupModule.expandAll();
    }

    if (args.item.id === 'collapseall') {
      this.grid.groupModule.collapseAll();
    }
  }


  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'customer_excelexport') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
      this.grid.excelExport();
    }
  }

}


