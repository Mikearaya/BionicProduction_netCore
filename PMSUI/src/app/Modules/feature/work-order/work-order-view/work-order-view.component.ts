/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:48 AM
 * @Description: Modify Here, Please
 */

import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  EditSettingsModel, CommandModel, RowSelectEventArgs, GroupSettingsModel,
  TextWrapSettingsModel, QueryCellInfoEventArgs, RowDataBoundEventArgs, Column, IRow, GridModel
} from '@syncfusion/ej2-grids';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { WorkOrderAPIService } from '../work-order-api.service';
import { workOrderBluePrint } from './work-order-view-blue-print';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { Tooltip } from '@syncfusion/ej2-popups';
import { closest } from '@syncfusion/ej2-base';


@Component({
  selector: 'app-work-order-view',
  templateUrl: './work-order-view.component.html',
  styleUrls: ['./work-order-view.component.css']
})

export class WorkOrderViewComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;
  public textWrapSettings: TextWrapSettingsModel;

  public data: DataManager;
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public groupOptions: GroupSettingsModel;
  public allowResizing = true;
  public showColumnChooser = true;
  public allowReordering = true;
  public allowTextWrap = false;

  public showColumnMenu = false;
  public allowFiltering = true;
  public allowSorting = true;
  public allowGrouping = true;
  public allowExcelExport = true;
  public allowPdfExport = true;
  public allowPaging = true;

  constructor(
    private workOrderApi: WorkOrderAPIService,
    private route: Router) {
   this.textWrapSettings = { wrapMode: 'Header' };

  }


  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public customAttributes: Object;
  columnBluePrint = workOrderBluePrint;

  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/workorders',
    adaptor: new WebApiAdaptor,
    offline: true
  });


  ngOnInit(): void {

    this.data = this.dataManager;
    this.pageSettings = { pageSize: 10 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: false, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'ColumnChooser', 'Print', 'Search', 'ExcelExport', 'PdfExport'];
    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
    this.groupOptions = {
      showDropArea: true,
      disablePageWiseAggregates: true
    };
    this.filterSetting = {
      type: 'Menu'
    };
    this.customAttributes = { class: 'custom-grid-header' };
    this.commands = [{
      type: 'Edit', buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-edit e-icons',
        click: this.editWorkOrder.bind(this)
      }
    },
    {
      type: 'Delete', buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-delete e-icons',
        click: this.deleteWorkOrder.bind(this)
      }
    }];
  }

  editWorkOrder(args: Event) {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`workorders/${rowObj.data['id']}/update`]);
  }
  deleteWorkOrder(args: any) {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.workOrderApi.deleteSingleWorkOrder(rowObj.data['id']).subscribe(
      succ => this.grid.refresh(),
      err => console.log(err));
  }
  tooltip(args: QueryCellInfoEventArgs) {
    const cell = args.cell;
    // const tooltip: Tooltip = new Tooltip({
    // content: args.data[args.column.field].toString();
    // }, cell)
  }

  dataBound() {

  }
  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.

    // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
  }

  rowDataBound(args: RowDataBoundEventArgs) {
    if (args.data['status'] === 'COMPLETED') {

      args.row.classList.add('completed-orders');
    } else if (args.data['status'] === 'IN-PROGRESS') {
      args.row.classList.add('in-progress-orders');
    } else {
      args.row.classList.add('queued-orders');
    }
  }

  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'workorder_excelexport') {
      this.grid.excelExport();
    } else if (args.item.id === 'workorder_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'workorder_print') {
      this.grid.print();
    } else if (args.item.id === 'workorder_add') {

      this.route.navigate(['workorders/new']);
    } else if (args.item.id === 'workorder_edit') {
      // console.log(args);
    } else if (args.item.id === 'workorder_delete') {

    }
  }

}


