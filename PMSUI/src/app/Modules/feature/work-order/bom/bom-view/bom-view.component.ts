/*
 * @CreateTime: Dec 5, 2018 11:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 7, 2018 11:32 PM
 * @Description: Modify Here, Please
 */
import { BomApiService } from '../../../../core/services/bom/bom-api.service';
import { bomColumBluePrint } from './bom-view-blue-print.model';
import { BomView } from 'src/app/Modules/core/DataModels/bom.model';
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

@Component({
  selector: 'app-bom-view',
  templateUrl: './bom-view.component.html',
  styleUrls: ['./bom-view.component.css']
})
export class BomViewComponent extends CommonProperties implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: BomView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public onLabel = 'Yes';
  public offLabel = 'No';

  public columnBluePrint = bomColumBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };

  constructor(
    private bomApi: BomApiService,
    private route: Router) {
    super();
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editBom.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteBom.bind(this) }
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

    this.bomApi.getAllBomItems().subscribe(
      (data: BomView[]) => {
        this.data = data;
      },
      this.handleError
    );


  }

  editBom(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`boms/${rowObj.data['id']}/update`]);

  }

  deleteBom(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.bomApi.deleteBomItem(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Bill of Material Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Bill of Material', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'bom_add':
        this.route.navigate([`boms/new`]);
        break;
      case 'bom_pdfexport':
        this.grid.pdfExport();
        break;
      case 'bom_excelexport':
        this.grid.excelExport();
        break;
      case 'bom_print':
        this.grid.print();
        break;
    }

  }

  closeChanged(data: any, status: boolean): void {

this.notification.showMessage('Sorry, Status Changing Not implemented currently', 'info');

  }

}
