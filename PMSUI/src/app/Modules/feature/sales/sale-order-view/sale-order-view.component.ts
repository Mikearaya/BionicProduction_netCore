import { Component, OnInit, ViewChild } from '@angular/core';
import { SaleOrderApiService } from '../sale-order-api.service';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel,
  EditSettingsModel, ToolbarItems, GroupSettingsModel, CommandModel, RowSelectEventArgs
} from '@syncfusion/ej2-grids';
import { Router } from '@angular/router';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { salesOrderBluePrint } from './sale-order-view-blue-print';

@Component({
  selector: 'app-sale-order-view',
  templateUrl: './sale-order-view.component.html',
  styleUrls: ['./sale-order-view.component.css']
})
export class SaleOrderViewComponent implements OnInit {
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
    private salesOrderApi: SaleOrderApiService,
    private route: Router) {

  }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  columnBluePrint = salesOrderBluePrint;

  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/salesorders',
    adaptor: new WebApiAdaptor,
    offline: true
  });


  ngOnInit(): void {

    this.data = this.dataManager;

    this.pageSettings = { pageSize: 10 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'ColumnChooser', 'Print', 'Search', 'ExcelExport', 'PdfExport'];
    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
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
  }


  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'salesorder_excelexport') {
      this.grid.excelExport();
    } else if (args.item.id === 'salesorder_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'salesorder_print') {
      this.grid.print();
    } else if (args.item.id === 'salesorder_add') {

      this.route.navigate(['sales/new']);
    } else if (args.item.id === 'salesorder_edit') {
      // console.log(args);
    } else if (args.item.id === 'salesorder_delete') {

    }
  }

}