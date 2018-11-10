/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 12:12 AM
 * @Description: Modify Here, Please
 */

import { Component, OnInit, ViewChild, Inject } from '@angular/core';

import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import {
  GridComponent, PageSettingsModel, SortSettingsModel,
  FilterSettingsModel, ToolbarItems, GroupSettingsModel, CommandModel
} from '@syncfusion/ej2-angular-grids';
import { stockViewColumnBluePrint } from './stock-column-blue-print';


@Component({
  selector: 'app-stock-view',
  templateUrl: './stock-view.component.html',
  styleUrls: ['./stock-view.component.css']
})

export class StockViewComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;
  public customAttributes: Object;

  public data: DataManager;
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

  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private route: Router) {

  }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  columnBluePrint = stockViewColumnBluePrint;

  public dataManager: DataManager = new DataManager({
    url: `${this.apiUrl}/finished_products`,
    adaptor: new WebApiAdaptor,
    offline: true
  });


  ngOnInit(): void {

    this.data = this.dataManager;
    this.customAttributes = { class: 'custom-grid-header' };

    this.pageSettings = { pageSize: 6 };
    this.toolbar = ['Print', 'Search', 'ExcelExport', 'PdfExport'];
    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
    this.groupOptions = {
      showDropArea: false,
      disablePageWiseAggregates: true
    };

    this.filterSetting = {
      type: 'Menu'
    };
  }


  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'finishedProducts_excelexport') {
      this.grid.excelExport();
    } else if (args.item.id === 'finishedProducts_pdfexport') {
      this.grid.pdfExport();
    } else if (args.item.id === 'finishedProducts_print') {
      this.grid.print();
    } else if (args.item.id === 'finishedProducts_add') {
      console.log('in');
      this.route.navigate(['finishedProducts/new']);
    }
  }

}


