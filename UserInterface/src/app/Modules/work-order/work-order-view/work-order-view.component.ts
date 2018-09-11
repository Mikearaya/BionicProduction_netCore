
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  EditSettingsModel, CommandModel, RowSelectEventArgs, GroupSettingsModel
} from '@syncfusion/ej2-grids';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { WorkOrderAPIService } from '../work-order-api.service';


@Component({
  selector: 'app-work-order-view',
  templateUrl: './work-order-view.component.html',
  styleUrls: ['./work-order-view.component.css']
})

export class WorkOrderViewComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  public data: DataManager;
  public pageSettings: PageSettingsModel;
  public allowResizing = true;
  public showColumnChooser = true;
  public allowReordering = true;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public groupOptions: GroupSettingsModel;
  public showColumnMenu = true;

  constructor(
    private workOrderApi: WorkOrderAPIService,
    private route: Router) {

  }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  productsViewColumns = [
    { key: 'id', humanReadable: 'Order ID', type: 'number', primaryKey: true,
    allowGrouping: true, editable: false, width: '50', isIdentity: true },
    {
      key: 'description', humanReadable: 'Description', primaryKey: false, type: 'string',
      editable: true, allowGrouping: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity: false, width: '100'
    },
    {
      key: 'orderId', humanReadable: 'ID', primaryKey: false, type: 'number', editable: true, allowGrouping: false, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity: false, width: '50'
    },
    {
      key: 'product', humanReadable: 'Product', primaryKey: false, type: 'string', allowGrouping: true, editable: true, dataType: 'TextBox',
      isIdentity: false, width: '70'
    },
    {
      key: 'quantity', humanReadable: 'Quantity', primaryKey: false, allowGrouping: true, type: 'number',
      editable: true, dataType: 'TextBox',
      isIdentity: false, width: '70'
    },
    {
      key: 'costPerItem', humanReadable: 'Unit Cost', type: 'number', primaryKey: false, format: 'C2',
      allowGrouping: true, editable: true, dataType: 'numericedit',
      validationRule: { required: true }, isIdentity: false, width: '70'
    },
    {
      key: 'orderDate', humanReadable: 'Ordered', type: 'date', primaryKey: false, allowGrouping: true, format: 'yMMMd',
      editable: true, dataType: 'datetime',
      validationRule: { required: true }, isIdentity: false, width: '100'
    },
    {
      key: 'dueDate', humanReadable: 'Due Date', allowGrouping: true, format: 'yMMMEd',
      primaryKey: false, editable: true, type: 'date', dataType: 'datetime',
      isIdentity: false, width: '100'
    },
    {
      key: 'orderedBy', humanReadable: 'Ordered By', type: 'string',
       primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
      isIdentity: false, width: '70'
    },
    {
      key: 'status', humanReadable: 'Status', type: 'boolean', primaryKey: false, allowGrouping: true, editable: true, dataType: 'TextBox',
      isIdentity: false, width: '50'
    }
  ];
  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/workorders',
    updateUrl: 'http://localhost:5000/api/workorders',
    insertUrl: 'http://localhost:5000/api/workorders',
    removeUrl: 'http://localhost:5000/api/workorders',
    adaptor: new WebApiAdaptor
  });


  ngOnInit(): void {

    this.data = this.dataManager;

    this.pageSettings = { pageSize: 6 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel', 'Print', 'Search', 'ExcelExport', 'Print', 'PdfExport'];
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
    { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
    this.groupOptions = {
      showDropArea: true,
      disablePageWiseAggregates: true, columns: ['id']
    };
  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
    // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
  }

  clickHandler(args: ClickEventArgs): void {

    if (args.item.id === 'workorder_add') {

    } else if (args.item.id === 'workorder_update') {
      // console.log(args);
    } else if (args.item.id === 'workorder_delete') {

    }
    if (args.item.id === 'expandall') {
      this.grid.groupModule.expandAll();
    }

    if (args.item.id === 'collapseall') {
      this.grid.groupModule.collapseAll();
    }
  }


  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'workorder_excelexport') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
      this.grid.excelExport();
    } else if (args.item.id === 'workorder_pdfexport') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
    this.grid.pdfExport();
  } else if (args.item.id === 'workorder_print') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
  this.grid.print();
}
  }

}


