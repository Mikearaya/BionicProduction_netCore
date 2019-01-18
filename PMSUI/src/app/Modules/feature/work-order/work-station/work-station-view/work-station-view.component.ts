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
import { WorkStationApiService } from 'src/app/Modules/core/services/work-station/work-station-api.service';
import { WorkstationView } from 'src/app/Modules/core/DataModels/workstation.model';
import { workstationViewBluePrint } from './works-station-column.model';

@Component({
  selector: 'app-work-station-view',
  templateUrl: './work-station-view.component.html',
  styleUrls: ['./work-station-view.component.css']
})
export class WorkStationViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: WorkstationView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = workstationViewBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private workstationApi: WorkStationApiService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {
    super();
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editStation.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteStation.bind(this) }
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

    this.workstationApi.getWorkStations().subscribe(
      (data: WorkstationView[]) => this.data = data,
      (error) => this.handleError
    );

  }

  editStation(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`${rowObj.data['groupId']}/stations/${rowObj.data['id']}`], { relativeTo: this.activatedRoute });

  }

  deleteStation(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.workstationApi.deleteWorkstation(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Workstation Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Workstation ', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'workstation_add':
        this.route.navigate(['new'], { relativeTo: this.activatedRoute });
        break;
      case 'workstation_pdfexport':
        this.grid.pdfExport();
        break;
      case 'workstation_excelexport':
        this.grid.excelExport();
        break;
      case 'workstation_print':
        this.grid.print();
        break;
    }

  }

  changeStatus(): void {
    this.notification.showMessage(`Sorry this feature is not currently implemented,
      use the workstation detail page instead to perform this action `, 'info');
  }

}
