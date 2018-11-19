import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import {
  CommandModel,
  EditSettingsModel,
  FilterSettingsModel,
  GroupSettingsModel,
  PageSettingsModel,
  RowSelectEventArgs,
  SortSettingsModel,
  ToolbarItems,
  IRow,
  Column
} from '@syncfusion/ej2-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ShipmentApiService } from '../../../core/services/shipment/shipment-api.service';
import { shipmentBluePrint } from './shipment-view-blue-print';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { closest } from '@syncfusion/ej2-base';

@Component({
  selector: 'app-shipment-view',
  templateUrl: './shipment-view.component.html',
  styleUrls: ['./shipment-view.component.css']
})
export class ShipmentViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

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
  public shipmentData: Object[];


  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public customAttributes: Object;
  columnBluePrint = shipmentBluePrint;



  constructor(
    private shipmentApi: ShipmentApiService,
    @Inject('BASE_URL') private apiUrl: string,
    private route: Router) {
    super();
    this.shipmentData = [];
    this.pageSettings = { pageSize: 10 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: false, allowAdding: true, allowDeleting: true };
    this.toolbar = ['ColumnChooser', 'Print', 'Search', 'ExcelExport', 'PdfExport'];
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
        click: this.viewShipment.bind(this)
      }
    },
    {
      type: 'Delete', buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-delete e-icons',
        click: this.cancelShipment.bind(this)
      }
    }];

  }


  ngOnInit(): void {
    this.shipmentApi.getAllShipmentSummary().subscribe(
      (data) => this.shipmentData = data,
    );


  }

  viewShipment(args: Event) {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`shipments/${rowObj.data['id']}`]);
  }

  // TODO: Implement Shipment Cancling
  cancelShipment(args: Event) {
    alert('sorry, feture not implemented yet');

  }


  toolbarClick(args: ClickEventArgs): void {
    switch (args.item.id) {
      case 'shipments_excelexport':
        this.grid.excelExport();
        break;
      case 'shipments_pdfexport':
        this.grid.pdfExport();
        break;
      case 'shipments_print':
        this.grid.print();
        break;
    }

  }
}
