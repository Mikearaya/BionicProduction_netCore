
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  EditSettingsModel, CommandModel, RowSelectEventArgs, GroupSettingsModel
} from '@syncfusion/ej2-grids';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { WorkOrderAPIService } from '../work-order-api.service';
import { GridComponent } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-pending-orders-view',
  templateUrl: './pending-orders-view.component.html',
  styleUrls: ['./pending-orders-view.component.css']
})
export class PendingOrdersViewComponent implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;

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

  }

  public customAttributes: Object;
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/workorders?type=pending',
    adaptor: new WebApiAdaptor,
    offline: true
  });

  ngOnInit(): void {

    this.customAttributes = {class: 'custom-grid-header'};

    this.data = this.dataManager;

    this.pageSettings = { pageSize: 10 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Delete', 'ColumnChooser', 'Print', 'Search', 'ExcelExport', 'PdfExport'];
    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'purchaseOrderItemId' }] };
    this.commands = [
      { type: 'Edit', buttonOption: {  content: 'CREATE ORDERED', cssClass:  'e-flat e-success', iconCss: 'e-check e-icons' } },
      { type: 'Delete', buttonOption: { content: 'REJECT', cssClass: 'e-flat e-delete e-danger', iconCss: 'e-delete e-icons' } }
    ];

    this.groupOptions = {
      showDropArea: true,
      disablePageWiseAggregates: true
    };
    this.filterSetting = {
      type: 'Menu'
    };
  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
    // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
    this.route.navigate([`workorders/request/${selectedrecords[0]['salesOrderItemId']}`]);

  }


  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'pendingOrder_excelexport') {
      this.grid.excelExport();
    } else if (args.item.id === 'pendingOrder_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'pendingOrder_print') {
      this.grid.print();
    } else if (args.item.id === 'pendingOrder_delete') {
      console.log(args);
    }
  }
}
