import { ActivatedRoute, Router } from '@angular/router';
import {
  CommandModel,
  EditSettingsModel,
  FilterSettingsModel,
  GroupSettingsModel,
  PageSettingsModel,
  QueryCellInfoEventArgs,
  ToolbarItems
} from '@syncfusion/ej2-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import {
  Component,
  Input,
  OnInit,
  ViewChild
} from '@angular/core';
import { EmitType } from '@syncfusion/ej2-base';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { invoicePaymentColumnBluePrint } from './invoice-payment-view-blue-print';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';

@Component({
  selector: 'app-invoice-payments-view',
  templateUrl: './invoice-payments-view.component.html',
  styleUrls: ['./invoice-payments-view.component.css']
})
export class InvoicePaymentsViewComponent extends CommonProperties implements OnInit {

  @Input() payments: any[];

  public data: any;
  public allowResizing = true;
  public allowReordering = true;

  public showColumnMenu = false;
  public allowFiltering = true;
  public allowSorting = true;
  public allowGrouping = true;
  public allowExcelExport = true;
  public allowPdfExport = true;
  public allowPaging = true;
  private invoiceId: number;

  public editSettings: EditSettingsModel;
  public pageSettings: PageSettingsModel;
  public filterOptions: FilterSettingsModel;
  public commands: CommandModel[];
  public columnBluePrint = invoicePaymentColumnBluePrint;
  public customAttributes: { class: string; };

  constructor(private saleInvoiceApi: SaleInvoiceApiService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    super();
    this.commands = [
      { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];
    this.customAttributes = { class: 'custom-grid-header' };
  }

  ngOnInit(): void {

    this.invoiceId = + this.activatedRoute.snapshot.paramMap.get('invoiceId');

    if (this.invoiceId) {
      this.saleInvoiceApi.getInvoiceById(this.invoiceId).subscribe(
        result => this.data = result,
        this.handleError);
    }
  }

  public queryCellInfoEvent: EmitType<QueryCellInfoEventArgs> = (args: QueryCellInfoEventArgs) => {

    if (args.column.field === 'Note') {
      args.colSpan = 2;
    }

  }

  addPayment(): void {
    this.router.navigate([`invoices/${this.invoiceId}/payments`]);
  }

}
