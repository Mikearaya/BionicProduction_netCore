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
  ToolbarItems
} from '@syncfusion/ej2-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Router } from '@angular/router';
import { StorageLocationApiService } from 'src/app/Modules/core/services/storage-location/storage-location-api.service';
import { StorageLocationView } from 'src/app/Modules/core/DataModels/storage-location.model';
import { storageLocationColumnBluePrint } from './storage-location-view.model';

@Component({
  selector: 'app-storage-location-view',
  templateUrl: './storage-location-view.component.html',
  styleUrls: ['./storage-location-view.component.css']
})
export class StorageLocationViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: StorageLocationView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = storageLocationColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private storageApi: StorageLocationApiService,
    private route: Router) {
    super();
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editStorage.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteStorage.bind(this) }
      }];

    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type

    this.pageSettings = { pageSize: 6 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
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

    this.storageApi.getAllStorageLocations().subscribe(
      (data: StorageLocationView[]) => this.data = data,
      this.handleError
    );

  }

  editStorage(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`storages/${rowObj.data['id']}/update`]);

  }

  deleteStorage(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.storageApi.deleteStorageLocation(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Storage LocationDeleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Storage Location', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'storage_add':
        this.route.navigate([`storages/new`]);
        break;
      case 'storage_pdfexport':
        this.grid.pdfExport();
        break;
      case 'storage_excelexport':
        this.grid.excelExport();
        break;
      case 'storage_print':
        this.grid.print();
        break;
    }

  }
}
