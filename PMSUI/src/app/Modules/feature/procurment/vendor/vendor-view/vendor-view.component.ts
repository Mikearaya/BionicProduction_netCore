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
  ToolbarItems
} from '@syncfusion/ej2-angular-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Router } from '@angular/router';
import { vendorColumnBluePrint } from './vendor-view-column.model';
import { VendorViewModel } from 'src/app/Modules/core/DataModels/vendor-data.model';
import { VendorApiService } from 'src/app/Modules/core/services/vendor/vendor-api.service';

@Component({
  selector: 'app-vendor-view',
  templateUrl: './vendor-view.component.html',
  styleUrls: ['./vendor-view.component.css']
})
export class VendorViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: VendorViewModel[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = vendorColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private vendorApi: VendorApiService,
    private route: Router) {
    super();
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editVendor.bind(this) }
      }, {
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



  ngOnInit(): void {

    this.vendorApi.getAllVendors().subscribe(
      (data: VendorViewModel[]) => this.data = data,
      this.handleError
    );

  }

  editVendor(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`procurments/vendors/${rowObj.data['id']}/update`]);

  }

  deleteVendor(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.vendorApi.deleteVendor(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Vendor Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Vendor', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'vendor_add':
        this.route.navigate([`procurments/vendors/new`]);
        break;
      case 'vendor_pdfexport':
        this.grid.pdfExport();
        break;
      case 'vendor_excelexport':
        this.grid.excelExport();
        break;
      case 'vendor_print':
        this.grid.print();
        break;
    }

  }
}
