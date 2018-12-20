import { Component, OnInit, ViewChild } from '@angular/core';
import { RoutingViewModel } from 'src/app/Modules/core/DataModels/production-routing.model';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import {
  GridComponent, Column, IRow, PageSettingsModel, SortSettingsModel,
  FilterSettingsModel, EditSettingsModel, ToolbarItems, CommandModel
} from '@syncfusion/ej2-angular-grids';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { routingColumnBluePrint } from './routing-view-column-blue-print.model';
import { RoutingApiService } from 'src/app/Modules/core/services/production-routing/routing-api.service';
import { Router } from '@angular/router';
import { closest } from '@syncfusion/ej2-base';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';

@Component({
  selector: 'app-routing-view',
  templateUrl: './routing-view.component.html',
  styleUrls: ['./routing-view.component.css']
})
export class RoutingViewComponent extends CommonProperties implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: RoutingViewModel[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = routingColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private productGroupApi: RoutingApiService,
    private route: Router) {
    super();
    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editRoute.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteRoute.bind(this) }
      }];

    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type

    this.pageSettings = { pageSize: 6 };
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

    this.productGroupApi.getAllProductionRoutings().subscribe(
      (data: RoutingViewModel[]) => this.data = data,
      (error: CustomErrorResponse) => this.handleError
    );

  }

  editRoute(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`routings/${rowObj.data['id']}/update`]);

  }

  deleteRoute(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.productGroupApi.deleteRoutingById(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Route Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Route', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'routing_add':
        this.route.navigate([`routings/new`]);
        break;
      case 'routing_pdfexport':
        this.grid.pdfExport();
        break;
      case 'routing_excelexport':
        this.grid.excelExport();
        break;
      case 'routing_print':
        this.grid.print();
        break;
    }

  }
}
