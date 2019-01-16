/*
 * @CreateTime: Dec 7, 2018 11:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 7, 2018 11:32 PM
 * @Description: Modify Here, Please
 */

import {
  Component,
  Input,
  ViewChild,
  AfterViewInit
} from '@angular/core';
import { BomView } from 'src/app/Modules/core/DataModels/bom.model';
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
import { BomApiService } from 'src/app/Modules/core/services/bom/bom-api.service';

@Component({
  selector: 'app-item-bom-list-view',
  templateUrl: './item-bom-list-view.component.html',
  styleUrls: ['./item-bom-list-view.component.css']
})
export class ItemBomListViewComponent extends CommonProperties implements AfterViewInit {



  @ViewChild('grid')
  public grid: GridComponent;
  @ViewChild('notification')
  public notification: NotificationComponent;
  @Input()
  public itemId: number;

  public data: BomView[];

  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];

  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private bomApi: BomApiService,
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

    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = [
      'Add'
    ];


  }

  ngAfterViewInit(): void {
    if (this.itemId !== 0) {
      this.bomApi.getItemBOMsById(this.itemId).subscribe(
        (data: BomView[]) => this.data = data,
        this.handleError
      );
    }
  }


  editGroup(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`boms/${rowObj.data['id']}/update`]);

  }

  deleteGroup(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.bomApi.deleteBomItem(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Product Group Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete product group', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    if (args.item.id && this.itemId) {
      this.route.navigate([`boms/new/${this.itemId}`]);
    }

  }
}
