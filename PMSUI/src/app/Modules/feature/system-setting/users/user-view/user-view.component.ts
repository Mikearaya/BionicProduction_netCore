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
import { UserApiService } from 'src/app/Modules/core/services/users/user-api.service';
import { userColumnBluePrint } from './user-view-column.model';
import { UserViewModel } from 'src/app/Modules/core/DataModels/user.model';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent extends CommonProperties implements OnInit {



  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: UserViewModel[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public wrapSettings: TextWrapSettingsModel;

  public columnBluePrint = userColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(private userApi: UserApiService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {

    super();
    this.commands = [
      {
        title: 'Edit User',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editUser.bind(this) }
      }, {
        title: 'Delete User',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteUser.bind(this) }
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

    this.userApi.getAllUsers().subscribe(
      (data: UserViewModel[]) => this.data = data,
      this.handleError
    );
  }

  editUser(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.router.navigate([`${rowObj.data['id']}/update`], { relativeTo: this.activatedRoute });

  }

  deleteUser(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.userApi.deleteUser(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('User deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete User', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'user_add':
        this.router.navigate(['new'], { relativeTo: this.activatedRoute });
        break;
      case 'user_pdfexport':
        this.grid.pdfExport();
        break;
      case 'user_excelexport':
        this.grid.excelExport();
        break;
      case 'user_print':
        this.grid.print();
        break;
    }

  }
}
