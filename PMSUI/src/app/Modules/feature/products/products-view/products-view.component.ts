/*
 * @CreateTime: Sep 8, 2018 11:03 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 8, 2018 11:09 PM
 * @Description: Products View Component Class
 */

import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  EditSettingsModel, CommandModel, RowSelectEventArgs
} from '@syncfusion/ej2-grids';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import {  Router } from '@angular/router';
import { ProductsAPIService } from '../products-api.service';
import { GridComponent } from '@syncfusion/ej2-angular-grids';


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
                  private productApiService: ProductsAPIService,
                  private route: Router ) {

      }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  productsViewColumns = [
    { key: 'id', humanReadable: 'ID', primaryKey: true, editable: false, isIdentity : true, width: '20px' },
    {
      key: 'code', humanReadable: 'Code', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity : false, width: '30px'
    },
    {
      key: 'name', humanReadable: 'Name', primaryKey: false, editable: true, dataType: 'TextBox',
      validationRule: { required: true }, isIdentity : false, width: '30px'
    },
    {
      key: 'discription', humanReadable: 'Discription', primaryKey: false, editable: true, dataType: 'TextBox',
      isIdentity : false, width: '50px'
    },
    {
      key: 'weight', humanReadable: 'Weight', primaryKey: false, editable: true, dataType: 'numericedit',
      validationRule: { required: true }, isIdentity : false, width: '30px'
    },
    {
      key: 'unit', humanReadable: 'Unit.', primaryKey: false, editable: true, dataType: 'textbox',
      validationRule: { required: true }, isIdentity : false, width: '30px'
    },
    { key: 'unitCost', humanReadable: 'Unit Cost', primaryKey: false, editable: true, dataType: 'numeric',
     isIdentity : false, width: '30px' }
  ];
  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/products',
    updateUrl: 'http://localhost:5000/api/products',
    insertUrl: 'http://localhost:5000/api/products',
    removeUrl: 'http://localhost:5000/api/products',
    adaptor: new WebApiAdaptor
  });


  ngOnInit(): void {

    this.data = this.dataManager;

    this.pageSettings = { pageSize: 6 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel', 'Print', 'Search', 'ExcelExport', 'ColumnChooser'];
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
        { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };

  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
    // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
}

  clickHandler(args: ClickEventArgs): void {

    if (args.item.id === 'product_add') {

    } else if (args.item.id === 'product_update') {
      // console.log(args);
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


