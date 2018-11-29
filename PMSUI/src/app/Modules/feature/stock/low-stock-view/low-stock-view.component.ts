/*
 * @CreateTime: Nov 11, 2018 12:13 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 12:13 AM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { LowStockItemsView } from '../../../core/DataModels/item-data-models';

import {
  GridComponent, PageSettingsModel, SortSettingsModel,
  FilterSettingsModel, ToolbarItems, GroupSettingsModel, CommandModel,
  EditSettingsModel, IRow, Column
} from '@syncfusion/ej2-angular-grids';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { lowStockViewBluePrint } from './low-stock-column-blue-print';
import { closest } from '@syncfusion/ej2-base';
import { ItemApiService } from '../stock-api.service';

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
    private itemApiService: ItemApiService) {

  }


  ngOnInit(): void {

    this.data = this.itemApiService.getLowInventoryItems()
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
        buttonOption: {
          content: 'Create',
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
