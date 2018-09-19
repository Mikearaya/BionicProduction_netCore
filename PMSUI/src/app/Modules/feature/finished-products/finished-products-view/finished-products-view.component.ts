/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 20, 2018 12:43 AM
 * @Description: Modify Here, Please
 */

import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PageSettingsModel, SortSettingsModel, FilterSettingsModel, ToolbarItems,
  EditSettingsModel, CommandModel, RowSelectEventArgs, GroupSettingsModel
} from '@syncfusion/ej2-grids';
import { WebApiAdaptor, DataManager } from '@syncfusion/ej2-data';

import { ClickEventArgs } from '@syncfusion/ej2-navigations';
import { Router } from '@angular/router';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { FinishedProductsApiService } from '../finished-products-api.service';


@Component({
  selector: 'app-finished-products-view',
  templateUrl: './finished-products-view.component.html',
  styleUrls: ['./finished-products-view.component.css']
})

export class FinishedProductsViewComponent implements OnInit {
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
  public groupOptions: GroupSettingsModel;
  public showColumnMenu = true;

  constructor(
    private finishedProductsApi: FinishedProductsApiService,
    private route: Router) {

  }

  public commands: CommandModel[];
  public printMode: 'CurrentPage';

  columnBluePrint = '';

  public dataManager: DataManager = new DataManager({
    url: 'http://localhost:5000/api/finished_products',
    adaptor: new WebApiAdaptor,
    offline: true
  });


  ngOnInit(): void {

    this.data = this.dataManager;

    this.pageSettings = { pageSize: 6 };
    this.editSettings = { showDeleteConfirmDialog: true, allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel', 'Print', 'Search', 'ExcelExport', 'Print', 'PdfExport'];
    this.commands = [{ type: 'Edit', buttonOption: { cssClass: 'e-flat', iconCss: 'e-edit e-icons' } },
    { type: 'Delete', buttonOption: { cssClass: 'e-flat', iconCss: 'e-delete e-icons' } }];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'OrderID' }] };
    this.groupOptions = {
      showDropArea: true,
      disablePageWiseAggregates: true, columns: ['id']
    };
  }

  rowSelected(args: RowSelectEventArgs) {
    const selectedrowindex: number[] = this.grid.getSelectedRowIndexes();  // Get the selected row indexes.
    // alert(selectedrowindex); // To alert the selected row indexes.
    const selectedrecords: Object[] = this.grid.getSelectedRecords();  // Get the selected records.
  }

  clickHandler(args: ClickEventArgs): void {
    alert('work');
    if (args.item.id === 'finishedProducts_add') {
      console.log('in');
      this.route.navigate(['finishedProducts/new']);
    } else if (args.item.id === 'finishedProducts_edit') {
      // console.log(args);
    } else if (args.item.id === 'finishedProducts_delete') {

    }
    if (args.item.id === 'expandall') {
      this.grid.groupModule.expandAll();
    }

    if (args.item.id === 'collapseall') {
      this.grid.groupModule.collapseAll();
    }
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


