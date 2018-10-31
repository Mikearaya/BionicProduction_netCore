import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { StockApiService } from '../stock-api.service';
import { LowStockItemsView } from '../stock-data-models';
import {
  GroupSettingsModel, FilterSettingsModel, ToolbarItems,
  SortSettingsModel, PageSettingsModel, CommandModel, IRow, Column, EditSettingsModel
} from '@syncfusion/ej2-grids';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { lowStockViewBluePrint } from './low-stock-column-blue-print';
import { closest } from '@syncfusion/ej2-base';

@Component({
  selector: 'app-low-stock-view',
  templateUrl: './low-stock-view.component.html',
  styleUrls: ['./low-stock-view.component.css']
})
export class LowStockViewComponent implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;
  public customAttributes: Object;

  public data: Object;
  public pageSettings: PageSettingsModel;
  public allowResizing = true;
  public showColumnChooser = true;
  public allowReordering = true;
  public allowGrouping = false;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public toolbar: ToolbarItems[];
  public groupOptions: GroupSettingsModel;
  public showColumnMenu = false;
  public allowPdfExport = true;
  public allowExcelExport = true;
  public allowFiltering = true;
  public allowSorting = true;
  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  columnBluePrint = lowStockViewBluePrint;
  public editSettings: EditSettingsModel;

  constructor(
    private route: Router,
    private stockApiService: StockApiService) {

  }


  ngOnInit(): void {

    this.data = this.stockApiService.getLowInventoryItems()
      .subscribe((data: LowStockItemsView[]) => this.data = data);

    this.customAttributes = { class: 'custom-grid-header' };

    this.pageSettings = { pageSize: 6 };
    this.toolbar = ['Print', 'Search', 'ExcelExport', 'PdfExport'];
    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
    this.groupOptions = {
      showDropArea: false,
      disablePageWiseAggregates: true
    };
    this.editSettings = { allowEditing: true, allowDeleting: true };

    this.filterSetting = {
      type: 'Menu'
    };

    this.commands = [
      {
        buttonOption: { content: 'Create',
          cssClass: 'e-success e-small',
          click: this.createManufactureOrder.bind(this)
        }
      }
    ];
  }


  createManufactureOrder(args: Event) {
    const rowObj: IRow<Column> = this.grid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`workorders/item/${rowObj.data['id']}`]);
  }

  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'lowStock_excelexport') {
      this.grid.excelExport();
    } else if (args.item.id === 'lowStock_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'lowStock_print') {
      this.grid.print();
    } else if (args.item.id === 'lowStock_add') {
      this.route.navigate(['workorders/create/']);
    }
  }

}
