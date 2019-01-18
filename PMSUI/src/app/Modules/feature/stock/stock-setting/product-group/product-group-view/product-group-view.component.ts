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
import {
  Component,
  OnInit,
  ViewChild
} from '@angular/core';

import { HttpErrorResponse } from '@angular/common/http';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { productGroupColumnBluePrint } from './product-group-view-blue-print';
import { ProductGroupView } from 'src/app/Modules/core/DataModels/product-group.model';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { ProductGroupApiService } from 'src/app/Modules/core/services/product-group/product-group-api.service';


@Component({
  selector: 'app-product-group-view',
  templateUrl: './product-group-view.component.html',
  styleUrls: ['./product-group-view.component.css']
})
export class ProductGroupViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: ProductGroupView[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  public columnBluePrint = productGroupColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private productGroupApi: ProductGroupApiService,
    private route: Router,
    private activatedRoute: ActivatedRoute) {
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

    this.productGroupApi.getAllProductGroups().subscribe(
      (data: ProductGroupView[]) => this.data = data,
      (error: HttpErrorResponse) => this.handleError
    );

  }

  editGroup(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`${rowObj.data['id']}/update`], { relativeTo: this.activatedRoute });

  }

  deleteGroup(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.productGroupApi.deleteProductGroup(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Product Group Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete product group', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'productgroups_add':
        this.route.navigate(['new'], { relativeTo: this.activatedRoute });
        break;
      case 'productgroups_pdfexport':
        this.grid.pdfExport();
        break;
      case 'productgroups_excelexport':
        this.grid.excelExport();
        break;
      case 'productgroups_print':
        this.grid.print();
        break;
    }

  }
}
