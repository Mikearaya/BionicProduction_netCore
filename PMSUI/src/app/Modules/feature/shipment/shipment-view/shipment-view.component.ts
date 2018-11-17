import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import {
  CommandModel,
  EditSettingsModel,
  FilterSettingsModel,
  GroupSettingsModel,
  PageSettingsModel,
  RowSelectEventArgs,
  SortSettingsModel,
  ToolbarItems
} from '@syncfusion/ej2-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ShipmentApiService } from '../shipment-api.service';
import { shipmentBluePrint } from './shipment-view-blue-print';
import { ShipmentSummaryView } from 'src/app/Modules/core/DataModels/shipment-data.model';
import { GridComponent } from '@syncfusion/ej2-angular-grids';

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

  constructor(
    private shipmentApi: ShipmentApiService,
    @Inject('BASE_URL') private apiUrl: string,
    private route: Router) {
    super();
    this.shipmentData = [];

  }


  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public customAttributes: Object;
  columnBluePrint = shipmentBluePrint;


  ngOnInit(): void {
    this.shipmentApi.getAllShipmentSummary().subscribe(
      (data) => this.shipmentData = data,
    );

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
  }
  deleteWorkOrder(args: any) {

  }


  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.

    // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
  }


  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'shipments_excelexport') {
      this.grid.excelExport();
    } else if (args.item.id === 'shipments_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'shipments_print') {
      this.grid.print();
    } else if (args.item.id === 'shipments_add') {
      this.route.navigate(['shipments/new']);
    } else if (args.item.id === 'shipments_edit') {
    } else if (args.item.id === 'shipments_delete') {

    }
  }
}
