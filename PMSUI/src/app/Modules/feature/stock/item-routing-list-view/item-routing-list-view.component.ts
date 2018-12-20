import {
  AfterViewInit,
  Component,
  Input,
  OnInit,
  ViewChild
} from '@angular/core';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { closest } from '@syncfusion/ej2-base';
import {
  Column,
  CommandModel,
  EditSettingsModel,
  GridComponent,
  IRow,
  ToolbarItems
} from '@syncfusion/ej2-angular-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Router } from '@angular/router';
import { RoutingApiService } from 'src/app/Modules/core/services/production-routing/routing-api.service';
import { RoutingViewModel } from 'src/app/Modules/core/DataModels/production-routing.model';

@Component({
  selector: 'app-item-routing-list-view',
  templateUrl: './item-routing-list-view.component.html',
  styleUrls: ['./item-routing-list-view.component.css']
})

export class ItemRoutingListViewComponent extends CommonProperties implements  AfterViewInit {

  @ViewChild('grid')
  public grid: GridComponent;
  @ViewChild('notification')
  public notification: NotificationComponent;
  @Input()
  public itemId: number;

  public data: RoutingViewModel[];

  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];

  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private routingApi: RoutingApiService,
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

    this.customAttributes = { class: 'info-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type

    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: false, allowAdding: true, allowDeleting: false };
    this.toolbar = [
      'Add'
    ];


  }

  ngAfterViewInit(): void {
    if (this.itemId !== 0) {
      this.routingApi.getItemRoutings(this.itemId).subscribe(
        (data: RoutingViewModel[]) => this.data = data,
        this.handleError
      );
    }
  }


  editRoute(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`routings/${rowObj.data['id']}/update`]);

  }

  deleteRoute(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.routingApi.deleteRoutingById(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Route Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Route', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    if (args.item.id && this.itemId) {
      this.route.navigate([`routings/new/${this.itemId}`]);
    }

  }
}
