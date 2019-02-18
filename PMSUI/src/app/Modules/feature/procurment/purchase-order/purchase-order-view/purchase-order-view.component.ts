import { ActivatedRoute, Router } from '@angular/router';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { closest } from '@syncfusion/ej2-base';
import {
  Column,
  CommandModel,
  EditSettingsModel,
  FilterSettingsModel,
  GridComponent,
  IRow,
  PageSettingsModel,
  SortSettingsModel,
  TextWrapSettingsModel,
  ToolbarItems
} from '@syncfusion/ej2-angular-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { PurchaseOrderApiService } from '../purchase-order-api.service';
import { purchaseOrderColumnBluePrint } from './purchase-order-view-column.model';
import { PurchaseOrderDetailView, PurchaseOrderListView } from '../pruchse-order-data.model';

@Component({
  selector: 'app-purchase-order-view',
  templateUrl: './purchase-order-view.component.html',
  styleUrls: ['./purchase-order-view.component.css']
})
export class PurchaseOrderViewComponent extends CommonProperties implements OnInit {


  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: PurchaseOrderListView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public wrapSettings: TextWrapSettingsModel;

  public columnBluePrint = purchaseOrderColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private purchaseOrderApi: PurchaseOrderApiService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {
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

    this.purchaseOrderApi.getAllPurchaseOrders().subscribe(
      (data: PurchaseOrderListView[]) => this.data = data,
      this.handleError
    );
  }

  editVendor(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`${rowObj.data['id']}/update`], { relativeTo: this.activatedRoute });

  }

  deleteVendor(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.purchaseOrderApi.deletePurchaseOrder(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Purchase Order Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Stock Batch', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'purchaseorder_add':
        this.route.navigate(['new'], { relativeTo: this.activatedRoute });
        break;
      case 'purchaseorder_pdfexport':
        this.grid.pdfExport();
        break;
      case 'purchaseorder_excelexport':
        this.grid.excelExport();
        break;
      case 'purchaseorder_print':
        this.grid.print();
        break;
    }

  }
}
