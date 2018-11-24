/*
 * @CreateTime: Nov 11, 2018 12:09 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 10:07 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { SaleOrderApiService } from '../sale-order-api.service';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel,
  EditSettingsModel, ToolbarItems, GroupSettingsModel, CommandModel, RowSelectEventArgs, IRow, Column
} from '@syncfusion/ej2-angular-grids';
import { Router } from '@angular/router';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { salesOrderBluePrint } from './sale-order-view-blue-print';
import { closest } from '@syncfusion/ej2-base';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-sale-order-view',
  templateUrl: './sale-order-view.component.html',
  styleUrls: ['./sale-order-view.component.css']
})
export class SaleOrderViewComponent extends CommonProperties implements OnInit {
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

  public customAttributes: Object;
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  columnBluePrint = salesOrderBluePrint;



  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private salesOrderApi: SaleOrderApiService,
    private route: Router) {
      super();


    this.pageSettings = { pageSize: 10 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'ColumnChooser', 'Print', 'Search', 'ExcelExport', 'PdfExport'];
    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
    this.groupOptions = {
      showDropArea: true,
      disablePageWiseAggregates: true
    };
    this.filterSetting = {
      type: 'Menu'
    };


    this.commands = [{
      buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-edit e-icons',
        click: this.viewOrder.bind(this)
      }
    },
    {
      type: 'Delete', buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-delete e-icons',
        click: this.deleteOrder.bind(this)
      }
    }];

    this.customAttributes = { class: 'custom-grid-header' };

  }


  public dataManager: DataManager = new DataManager({
    url: `${this.apiUrl}/salesorders`,
    adaptor: new WebApiAdaptor,
    offline: true
  });


  ngOnInit(): void {

    this.data = this.dataManager;

  }

  viewOrder(args: Event) {

    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    console.log(rowObj.data);
    this.route.navigate([`sales/${rowObj.data['id']}`]);
  }

  deleteOrder(args: any) {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.salesOrderApi.deleteSalesOrder(rowObj.data['id']).subscribe(
      succ => this.grid.refresh(),
      err => this.handleError
    );
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
