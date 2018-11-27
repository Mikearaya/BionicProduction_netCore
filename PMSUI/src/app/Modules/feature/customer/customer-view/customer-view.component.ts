/*
 * @CreateTime: Sep 5, 2018 8:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 26, 2018 11:02 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewChild, Inject } from '@angular/core';

import { CustomerService } from '../../../core/services/customers/customer.service';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import {
  GridComponent, PageSettingsModel, SortSettingsModel, FilterSettingsModel
  , EditSettingsModel, ToolbarItems, CommandModel, RowSelectEventArgs
} from '@syncfusion/ej2-angular-grids';
import { customerViewColumnsBluePrint } from './customer-view-blue-print.model';


@Component({
  selector: 'app-customer-view',
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
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public customerViewColumns = customerViewColumnsBluePrint;
  customAttributes: { class: string; };
  filterOptions: { type: string; };


  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private customerService: CustomerService,
    private route: Router) {
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editCustomer.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteCustomer.bind(this) }
      }];

    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type

    this.pageSettings = { pageSize: 6 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = [
      'Add',
      'Print',
      'ExcelExport',
      'PdfExport',
      'Search',
      'ColumnChooser'
    ];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };

  }

  public dataManager: DataManager = new DataManager({
    url: `${this.apiUrl}/customers`,
    adaptor: new WebApiAdaptor,
    offline: true
  });

  ngOnInit(): void {
    this.data = this.dataManager;
  }

  editCustomer(arg: Event): void {

  }

  deleteCustomer(arg: Event): void {

  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
  }

  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'customer_add':
        this.route.navigate([`customers/new`]);
        break;
      case 'customer_pdfexport':
        this.grid.pdfExport();
        break;
      case 'customer_excelexport':
        this.grid.excelExport();
        break;
      case 'customer_print':
        this.grid.print();
        break;
    }

  }



}


