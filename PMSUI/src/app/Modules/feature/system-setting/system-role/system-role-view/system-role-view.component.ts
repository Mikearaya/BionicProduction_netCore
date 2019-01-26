import { ActivatedRoute, Router } from '@angular/router';
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
  TextWrapSettingsModel,
  ToolbarItems
} from '@syncfusion/ej2-angular-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { RoleListViewModel } from '../system-role-data.model';
import { SystemRoleApiService } from '../system-role-api.service';
import { systemRoleColumnBluePrint } from './system-role-view-column.model';

@Component({
  selector: 'app-system-role-view',
  templateUrl: './system-role-view.component.html',
  styleUrls: ['./system-role-view.component.css']
})
export class SystemRoleViewComponent extends CommonProperties implements OnInit {


  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: RoleListViewModel[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public wrapSettings: TextWrapSettingsModel;

  public columnBluePrint = systemRoleColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(private roleApi: SystemRoleApiService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {

    super();
    this.commands = [
      {
        title: 'Edit Role',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editRole.bind(this) }
      }, {
        title: 'Delete Role',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteRole.bind(this) }
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
  dataBound() {

  }

  ngOnInit(): void {
    this.wrapSettings = { wrapMode: 'Header' };

    this.roleApi.getAllSystemRoles().subscribe(
      (data: RoleListViewModel[]) => this.data = data,
      this.handleError
    );
  }

  editRole(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.router.navigate([`${rowObj.data['id']}/update`], { relativeTo: this.activatedRoute });

  }

  deleteRole(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.roleApi.deleteSystemRole(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('System Role Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete System Role', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'role_add':
        this.router.navigate(['new'], { relativeTo: this.activatedRoute });
        break;
      case 'role_pdfexport':
        this.grid.pdfExport();
        break;
      case 'role_excelexport':
        this.grid.excelExport();
        break;
      case 'role_print':
        this.grid.print();
        break;
    }

  }
}
