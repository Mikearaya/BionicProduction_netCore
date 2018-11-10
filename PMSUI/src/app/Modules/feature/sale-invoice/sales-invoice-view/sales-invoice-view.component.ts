import { Component, OnInit, ViewChild } from '@angular/core';
import {
  GridComponent, GroupSettingsModel, FilterSettingsModel,
  ToolbarItems, TextWrapSettingsModel, EditSettingsModel, SelectionSettingsModel,
  PageSettingsModel, CommandModel
} from '@syncfusion/ej2-angular-grids';
import { Router } from '@angular/router';
import { saleInvoiceColumnBluePrint } from './sales-invoice-view-blue-print';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';
import { InvoiceDetail } from '../../../core/DataModels/invoice-data-model';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';


@Component({
  selector: 'app-sales-invoice-view',
  templateUrl: './sales-invoice-view.component.html',
  styleUrls: ['./sales-invoice-view.component.css']
})
export class SalesInvoiceViewComponent implements OnInit {

  title = 'Invoice';

  @ViewChild('grid')
  public grid: GridComponent;
  public data: InvoiceDetail[];
  public groupOptions: GroupSettingsModel;
  public filterSettings: FilterSettingsModel;
  public toolbarOptions: ToolbarItems[];
  public wrapSettings: TextWrapSettingsModel;
  public toolbar: ToolbarItems[];
  public editSettings: EditSettingsModel;
  public pageSettings: PageSettingsModel;
  public filterOptions: FilterSettingsModel;
  public commands: CommandModel[];
  public columnBluePrint = saleInvoiceColumnBluePrint;
  public customAttributes: { class: string; };

  constructor(private router: Router,
              private invoiceApi: SaleInvoiceApiService) {
    this.commands = [
      { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } },
      { type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } }];
      this.customAttributes = { class: 'custom-grid-header' };
      this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
      this.groupOptions = { showGroupedColumn: true }; // make columns used for grouping visable
      this.toolbarOptions = [
      'Print',
      'PdfExport',
      'ExcelExport',
      'Search'
    ];
    this.data = [];
    this.pageSettings = { pageSize: 5 };  // initial page row size for the grid
    this.editSettings = { allowEditing: true, allowDeleting: true };
  }

  ngOnInit() {

    this.invoiceApi.getAllInvoicesSummary().subscribe(
      (data: InvoiceDetail[]) => this.data = data,
      (error: CustomErrorResponse) => console.log(error)
    );


  }

  addInvoice() {
    this.router.navigate([`invoices/create`]);
  }

  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'invoice_edit') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
        console.log(args);
    } else if (args.item.id === 'invoice_delete') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name

    }
}

}
