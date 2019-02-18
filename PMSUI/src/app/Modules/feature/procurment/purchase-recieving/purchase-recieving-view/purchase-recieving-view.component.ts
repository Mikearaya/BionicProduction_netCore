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
import { PurchaseOrderApiService } from '../../purchase-order-api.service';
import { PurchaseOrderListView } from '../../purchase-order/pruchse-order-data.model';
import { purchaseRecievingColumnBluePrint } from './purchase-recieving-view-column.model';

@Component({
  selector: 'app-purchase-recieving-view',
  templateUrl: './purchase-recieving-view.component.html',
  styleUrls: ['./purchase-recieving-view.component.css']
})
export class PurchaseRecievingViewComponent extends CommonProperties implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;

  public data: PurchaseOrderListView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public wrapSettings: TextWrapSettingsModel;

  public columnBluePrint = purchaseRecievingColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private purchaseOrderApi: PurchaseOrderApiService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {
    super();
    this.commands = [
      {
        title: 'Open purchase order',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.viewPurchaseOrder.bind(this) }
      }];

    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type

    this.pageSettings = { pageSize: 10 };
    this.editSettings = { allowEditing: false, allowAdding: true, allowDeleting: false };
    this.toolbar = [
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

    this.purchaseOrderApi.getShippedPurchaseOrders().subscribe(
      (data: PurchaseOrderListView[]) => this.data = data,
      this.handleError
    );
  }

  viewPurchaseOrder(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`${rowObj.data['id']}/update`], { relativeTo: this.activatedRoute });

  }


  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
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
