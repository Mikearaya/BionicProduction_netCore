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
import { Router, ActivatedRoute } from '@angular/router';
import { unitOfMeasurementColumnBluePrint } from './unit-of-measurment-view-blue-print';
import { UnitOfMeasurmentApiService } from 'src/app/Modules/core/services/unit-of-measurment/unit-of-measurment-api.service';
import { UnitOfMeasurmentView } from 'src/app/Modules/core/DataModels/unit-of-measurment.mode';

@Component({
  selector: 'app-unit-of-measurment-view',
  templateUrl: './unit-of-measurment-view.component.html',
  styleUrls: ['./unit-of-measurment-view.component.css']
})
export class UnitOfMeasurmentViewComponent extends CommonProperties implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: UnitOfMeasurmentView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = unitOfMeasurementColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private unitOfMeasureApi: UnitOfMeasurmentApiService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {
    super();
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editUom.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteUom.bind(this) }
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

    this.unitOfMeasureApi.getAllUnitOfMeasures().subscribe(
      (data: UnitOfMeasurmentView[]) => this.data = data,
      this.handleError
    );

  }

  editUom(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`${rowObj.data['id']}/update`], { relativeTo: this.activatedRoute });

  }

  deleteUom(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.unitOfMeasureApi.deleteUnitOfMeasurment(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Unit of Measurement Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Unit of Measurment', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'uom_add':
        this.route.navigate(['new'], { relativeTo: this.activatedRoute });
        break;
      case 'uom_pdfexport':
        this.grid.pdfExport();
        break;
      case 'uom_excelexport':
        this.grid.excelExport();
        break;
      case 'uom_print':
        this.grid.print();
        break;
    }

  }
}
