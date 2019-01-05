import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { closest } from '@syncfusion/ej2-base';
import {
  Column,
  CommandModel,
  EditSettingsModel,
  FilterSettingsModel,
  IRow,
  PageSettingsModel,
  SortSettingsModel,
  ToolbarItems,
  TextWrapSettingsModel
} from '@syncfusion/ej2-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Router } from '@angular/router';
import { stockBatchColumnBluePrint } from './stock-batch-view-blue-print.model';
import { StockBatchListView } from 'src/app/Modules/core/DataModels/stock-batch.model';
import { StockBatchApiService } from 'src/app/Modules/core/services/stock-batch/stock-batch-api.service';

@Component({
  selector: 'app-stock-batch-view',
  templateUrl: './stock-batch-view.component.html',
  styleUrls: ['./stock-batch-view.component.css']
})
export class StockBatchViewComponent extends CommonProperties implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: StockBatchListView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public wrapSettings: TextWrapSettingsModel;

  public columnBluePrint = stockBatchColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private stockBatchApi: StockBatchApiService,
    private route: Router) {
    super();
    this.commands = [
      {
        title: 'Edit Batch',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editVendor.bind(this) }
      }, {
        title: 'Delete Batch',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteVendor.bind(this) }
      }];

    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type

    this.pageSettings = { pageSize: 10 };
    this.editSettings = { allowEditing: false, allowAdding: true, allowDeleting: false };
    this.toolbar = [
      'Add',
      'Print',
      'ExcelExport',
      'PdfExport',
      'Search',
      'ColumnChooser'
    ];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'id' }] };

  }
  dataBound() {

  }

  ngOnInit(): void {
    this.wrapSettings = { wrapMode: 'Header' };

    this.stockBatchApi.getAllStockBatchs().subscribe(
      (data: StockBatchListView[]) => this.data = data,
      this.handleError
    );

  }

  editVendor(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`inventory/batchs/${rowObj.data['id']}/update`]);

  }

  deleteVendor(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.stockBatchApi.deleteStockBatch(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Batch Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Stock Batch', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'stockbatch_add':
        this.route.navigate([`inventory/batchs/new`]);
        break;
      case 'stockbatch_pdfexport':
        this.grid.pdfExport();
        break;
      case 'stockbatch_excelexport':
        this.grid.excelExport();
        break;
      case 'stockbatch_print':
        this.grid.print();
        break;
    }

  }

}
