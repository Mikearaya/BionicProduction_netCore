/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 20, 2018 1:34 AM
 * @Description: Modify Here, Please
 */

import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  CommandModel, GroupSettingsModel
} from '@syncfusion/ej2-grids';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { GridComponent } from '@syncfusion/ej2-ng-grids';

import { finishedProductsBluePrint } from './current-stock-column-blue-print';


@Component({
  selector: 'app-current-stock-view',
  templateUrl: './current-stock-view.component.html',
  styleUrls: ['./current-stock-view.component.css']
})

export class CurrentStockViewComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

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
    private route: Router) {

  }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  columnBluePrint = finishedProductsBluePrint;

  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/finished_products',
    adaptor: new WebApiAdaptor,
    offline: true
  });


  ngOnInit(): void {

    this.data = this.dataManager;

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


