import {
  CommandModel,
  EditSettingsModel,
  FilterSettingsModel,
  GridComponent,
  PageSettingsModel,
  SortSettingsModel,
  ToolbarItems,
  IRow,
  Column
} from '@syncfusion/ej2-angular-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Router, ActivatedRoute } from '@angular/router';
import { WriteOffApiService } from '../write-off-api.service';
import { writeOffColumnBluePrint } from './write-off-view-blue-print.model';
import { WriteOffListModel } from '../write-off-data.model';
import { closest } from '@syncfusion/ej2-base';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';

@Component({
  selector: 'app-write-off-view',
  templateUrl: './write-off-view.component.html',
  styleUrls: ['./write-off-view.component.css']
})
export class WriteOffViewComponent extends CommonProperties implements OnInit {


  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: WriteOffListModel[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = writeOffColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private writeOffApi: WriteOffApiService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {
    super();
    this.commands = [
      {
        title: 'Edit Write-Off',
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editWriteOff.bind(this) }
      }

    ];

    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
    this.editSettings = { allowEditing: false, allowAdding: true, allowDeleting: false };
    this.pageSettings = { pageSize: 10 };
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

    this.writeOffApi.getAllWriteOffs().subscribe(
      (data: WriteOffListModel[]) => this.data = data,
      this.handleError
    );

  }

  editWriteOff(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`${rowObj.data['id']}/update`], { relativeTo: this.activatedRoute });

  }

  deleteWriteOff(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.writeOffApi.deleteWriteOff(rowObj.data['writeOffId']).subscribe(
      () => this.notification.showMessage('Wite off Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete Write off', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'writeoff_add':
        this.route.navigate(['new'], { relativeTo: this.activatedRoute });
        break;
      case 'writeoff_pdfexport':
        this.grid.pdfExport();
        break;
      case 'writeoff_excelexport':
        this.grid.excelExport();
        break;
      case 'writeoff_print':
        this.grid.print();
        break;
    }

  }

}
