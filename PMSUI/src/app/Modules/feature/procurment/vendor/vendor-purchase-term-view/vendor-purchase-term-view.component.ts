import {
  AfterViewInit,
  Component,
  OnInit,
  ViewChild,
  Input
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
import { PurchaseTermApiService } from 'src/app/Modules/core/services/purchase-terms/purchase-term-api.service';
import { PurchaseTermViewModel } from 'src/app/Modules/core/DataModels/purchase-terms-data.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vendor-purchase-term-view',
  templateUrl: './vendor-purchase-term-view.component.html',
  styleUrls: ['./vendor-purchase-term-view.component.css']
})
export class VendorPurchaseTermViewComponent extends CommonProperties implements AfterViewInit {
  purchaseTerms: PurchaseTermViewModel[];

  @Input()
  public vendorId: number;

  @ViewChild('grid')
  public grid: GridComponent;
  @ViewChild('notification')
  public notification: NotificationComponent;

  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];

  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private purchaseTermApi: PurchaseTermApiService,
    private route: Router) {
    super();

    this.commands = [
      {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.editTerm.bind(this) }
      }, {
        buttonOption:
          { cssClass: 'e-flat', iconCss: 'e-delete e-icons', click: this.deleteTerm.bind(this) }
      }];

    this.customAttributes = { class: 'custom-grid-header' };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = [
      'Add'
    ];
  }

  ngAfterViewInit(): void {

    if (this.vendorId !== 0) {
      this.purchaseTermApi.getVendorPurchseTerms(this.vendorId).subscribe(
        (data: PurchaseTermViewModel[]) => this.purchaseTerms = data,
        this.handleError
      );

    }

  }

  editTerm(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`procurments/purchase-terms/${rowObj.data['id']}`]);

  }

  deleteTerm(args: Event): void {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.purchaseTermApi.deletePurchaseTerm(rowObj.data['id']).subscribe(
      () => this.notification.showMessage('Purchase Term Deleted'),
      (error: CustomErrorResponse) => {
        this.notification.showMessage('Unable to Delete purchase term try again later', 'error');
        this.handleError(error);
      }
    );
  }



  toolbarClick(args: ClickEventArgs): void {

    if (args.item.id && this.vendorId) {
      this.route.navigate([`procurments/purchase-terms/vendor/${this.vendorId}`]);
    }

  }



}
