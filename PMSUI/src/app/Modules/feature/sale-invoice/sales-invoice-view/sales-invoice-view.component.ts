/*
 * @CreateTime: Nov 11, 2018 12:05 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 8:43 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  GridComponent, GroupSettingsModel, FilterSettingsModel,
  ToolbarItems, TextWrapSettingsModel, EditSettingsModel, SelectionSettingsModel,
  PageSettingsModel, CommandModel, PdfExportProperties, Column, IRow
} from '@syncfusion/ej2-angular-grids';
import { Router } from '@angular/router';
import { saleInvoiceColumnBluePrint } from './sales-invoice-view-blue-print';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { SaleInvoiceApiService } from '../sale-invoice-api.service';
import { InvoiceDetail } from '../../../core/DataModels/invoice-data-model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { closest } from '@syncfusion/ej2-base';


@Component({
  selector: 'app-sales-invoice-view',
  templateUrl: './sales-invoice-view.component.html',
  styleUrls: ['./sales-invoice-view.component.css']
})
export class SalesInvoiceViewComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;
  public data: any[];
  public groupOptions: GroupSettingsModel;
  public filterSettings: FilterSettingsModel;
  public toolbarOptions: ToolbarItems[];
  public allowResizing = true;
  public showColumnChooser = true;
  public allowReordering = true;

  public showColumnMenu = false;
  public allowFiltering = true;
  public allowSorting = true;
  public allowGrouping = true;
  public allowExcelExport = true;
  public allowPdfExport = true;
  public allowPaging = true;

  public wrapSettings: TextWrapSettingsModel;
  public toolbar: ToolbarItems[];
  public editSettings: EditSettingsModel;
  public pageSettings: PageSettingsModel;
  public filterOptions: FilterSettingsModel;
  public commands: CommandModel[];
  public columnBluePrint = saleInvoiceColumnBluePrint;
  public customAttributes: { class: string; };

  constructor(
    private router: Router,
    private invoiceApi: SaleInvoiceApiService) {
    super();
    this.commands = [
      {buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons', click: this.viewInvoice.bind(this)} }];
    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
    this.groupOptions = { showGroupedColumn: true }; // make columns used for grouping visable
    this.toolbarOptions = [
      'Print',
      'PdfExport',
      'ExcelExport',
      'ColumnChooser',
      'Search'


    ];
    this.data = [];
    this.pageSettings = { pageSize: 5 };  // initial page row size for the grid
    this.editSettings = { allowEditing: true, allowDeleting: true };
  }

  viewInvoice(args: Event): void {
    console.log(args);
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.router.navigate([`invoices/${rowObj.data['Id']}`]);

  }

  ngOnInit() {

    this.invoiceApi.getAllInvoicesSummary().subscribe(
      (data: InvoiceDetail[]) => this.data = data,
      this.handleError
    );


  }

  addInvoice() {
    this.router.navigate(['invoices/create']);
  }

  toolbarClick(args: ClickEventArgs): void {
    switch (args.item.id) {
      case 'invoice_pdfexport':
      const exportProperties: PdfExportProperties = {
        pageSize: 'A4'
    };
        this.grid.pdfExport(exportProperties);
        break;
      case 'invoice_excelexport':
        this.grid.excelExport();
        break;
      case 'invoice_print':
      this.grid.print();
        break;

    }
  }

}
