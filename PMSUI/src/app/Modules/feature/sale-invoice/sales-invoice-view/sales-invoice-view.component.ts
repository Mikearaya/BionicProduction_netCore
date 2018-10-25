import { Component, OnInit, ViewChild } from '@angular/core';
import {
  GridComponent, GroupSettingsModel, FilterSettingsModel,
  ToolbarItems, TextWrapSettingsModel, EditSettingsModel, SelectionSettingsModel,
  PageSettingsModel, CommandModel
} from '@syncfusion/ej2-ng-grids';
import { Router } from '@angular/router';
import { saleInvoiceColumnBluePrint } from './sales-invoice-view-blue-print';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';

@Component({
  selector: 'app-sales-invoice-view',
  templateUrl: './sales-invoice-view.component.html',
  styleUrls: ['./sales-invoice-view.component.css']
})
export class SalesInvoiceViewComponent implements OnInit {

  title = 'Invoice';

  @ViewChild('grid')
  public grid: GridComponent;
  public data: any[];
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

  constructor(private router: Router) {
    this.commands = [
      { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } },
      { type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } }];

  }

  ngOnInit() {
    this.data = [];

    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
    this.groupOptions = { showGroupedColumn: true }; // make columns used for grouping visable
    this.toolbarOptions = [
      'Add',
      'Print',
      'PdfExport',
      'ExcelExport',
      'Search'
    ];

    this.pageSettings = { pageSize: 5 };  // initial page row size for the grid
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
  }

  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'invoice_add') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
        this.router.navigate([`invoices/new`]);
    }
}

}
