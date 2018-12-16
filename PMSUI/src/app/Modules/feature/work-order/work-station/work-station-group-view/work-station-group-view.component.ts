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
import { WorkStationApiService } from 'src/app/Modules/core/services/work-station/work-station-api.service';
import { WorkstationGroupView } from 'src/app/Modules/core/DataModels/workstation.model';
import { workstationGroupViewBluePrint } from './workstation-group-view.model';

@Component({
  selector: 'app-work-station-group-view',
  templateUrl: './work-station-group-view.component.html',
  styleUrls: ['./work-station-group-view.component.css']
})
export class WorkStationGroupViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: WorkstationGroupView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = workstationGroupViewBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private workstationApi: WorkStationApiService,
    private route: Router) {
    super();
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editGroup.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteGroup.bind(this) }
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

    this.workstationApi.getWorkStationGroups().subscribe(
      (data: WorkstationGroupView[]) => this.data = data,
      (error) => this.handleError
    );

  }

  editGroup(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`work-stations/${rowObj.data['id']}/update`]);

  }

  deleteGroup(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.workstationApi.deleteWorkstationGroup(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Workstation Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Workstation group', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'workstationGroup_add':
        this.route.navigate([`work-stations/new`]);
        break;
      case 'workstationGroup_pdfexport':
        this.grid.pdfExport();
        break;
      case 'workstationGroup_excelexport':
        this.grid.excelExport();
        break;
      case 'workstationGroup_print':
        this.grid.print();
        break;
    }

  }

  changeStatus(): void {
    this.notification.showMessage(`Sorry this feature is not currently implemented,
      use the workstation group detail page instead to perform this action `, 'info');
  }

}
