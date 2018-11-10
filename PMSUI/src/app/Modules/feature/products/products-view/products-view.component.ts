/*
 * @CreateTime: Sep 8, 2018 11:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 12:05 AM
 * @Description: Products View Component Class
 */

import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  EditSettingsModel, CommandModel, RowSelectEventArgs
} from '@syncfusion/ej2-angular-grids';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { ProductsAPIService } from '../products-api.service';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { productsViewBluePrint } from './products-view-blue-print';


@Component({
  selector: 'app-products-view',
  templateUrl: './products-view.component.html',
  styleUrls: ['./products-view.component.css']
})

export class ProductsViewComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;

  public data: DataManager;
  public pageSettings: PageSettingsModel;
  public allowResizing = true;
  public showColumnChooser = true;
  public allowReordering = true;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public showColumnMenu = true;

  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private productApiService: ProductsAPIService,
    private route: Router) {

    this.customAttributes = { class: 'custom-grid-header' };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel', 'Print', 'Search', 'ExcelExport', 'ColumnChooser'];
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
    { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };

  }

  public customAttributes: Object;

  public commands: CommandModel[];
  public printMode: 'CurrentPage';
  public columnBluePrint = productsViewBluePrint;

  public dataManager: DataManager = new DataManager({
    url: `${this.apiUrl}/products`,
    updateUrl: `${this.apiUrl}/products`,
    insertUrl: `${this.apiUrl}/products`,
    removeUrl: `${this.apiUrl}/products`,
    adaptor: new WebApiAdaptor
  });


  ngOnInit(): void {


  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
    // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
  }

  clickHandler(args: ClickEventArgs): void {

    if (args.item.id === 'product_add') {

    } else if (args.item.id === 'product_update') {

    } else if (args.item.id === 'product_delete') {

    }
    if (args.item.id === 'expandall') {
      this.grid.groupModule.expandAll();
    }

    if (args.item.id === 'collapseall') {
      this.grid.groupModule.collapseAll();
    }
  }


  toolbarClick(args: ClickEventArgs): void {
    if (args.item.id === 'product_excelexport') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
      this.grid.excelExport();
    }
  }

}


