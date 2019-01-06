import {
  CommandModel,
  EditSettingsModel,
  FilterSettingsModel,
  PageSettingsModel,
  SortSettingsModel,
  ToolbarItems
} from '@syncfusion/ej2-grids';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { InventoryViewModel } from '../inventory-data.model';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { GridComponent } from '@syncfusion/ej2-angular-grids';
import { inventoryColumnBluePrint } from './inventory-view-columns-blue-print.model';
import { InventoryApiService } from '../inventory-api.service';
import { Router } from '@angular/router';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';

@Component({
  selector: 'app-inventory-view',
  templateUrl: './inventory-view.component.html',
  styleUrls: ['./inventory-view.component.css']
})
export class InventoryViewComponent extends CommonProperties implements OnInit {


  @ViewChild('grid')
  public grid: GridComponent;

  @ViewChild('notification')
  private notification: NotificationComponent;

  public data: InventoryViewModel[];
  public pageSettings: PageSettingsModel;
  public sortSetting: SortSettingsModel;
  public filterSetting: FilterSettingsModel;
  public editSettings: EditSettingsModel;
  public toolbar: ToolbarItems[];
  public printMode: 'CurrentPage';

  public columnBluePrint = inventoryColumnBluePrint;
  public customAttributes: { class: string; };
  public filterOptions: { type: string; };


  constructor(
    private inventoryApi: InventoryApiService,
    private route: Router) {
    super();

    this.customAttributes = { class: 'custom-grid-header' };
    this.filterOptions = { type: 'Menu' }; // put unique filter menue for each column based on the column type
    this.editSettings = { allowEditing: false, allowAdding: true, allowDeleting: false };
    this.pageSettings = { pageSize: 10 };
    this.toolbar = [
      'Print',
      'ExcelExport',
      'PdfExport',
      'Search',
      'ColumnChooser'
    ];

    this.sortSetting = { columns: [{ direction: 'Ascending', field: 'item' }] };

  }

  clicked(data: any) {
    console.log(data);
    const item = <InventoryViewModel>data;

    if (item.newQuantity < item.quantity) {
      alert('is Write off');
    } else if (item.newQuantity > item.quantity) {
      alert('is new Batch');
    }
    console.log(this.data[data.index]);
  }
  ngOnInit(): void {

    this.inventoryApi.getInventoryList().subscribe(
      (data: InventoryViewModel[]) => this.data = data,
      this.handleError
    );

  }


  updateAllInventory(data: any) {
    console.log('update all');
    const rows = this.grid.getDataRows();
    console.log(rows);
  }

  updateInventory(data: any) {
    console.log('update 1');
    console.log(data);
  }
  public quantityValue = (field: string, data: Object, column: Object) => {
    return data[field] + ' ' + data['uom'];
  }


  toolbarClick(args: ClickEventArgs): void {

    switch (args.item.id) {
      case 'inventory_pdfexport':
        this.grid.pdfExport();
        break;
      case 'inventory_excelexport':
        this.grid.excelExport();
        break;
      case 'inventory_print':
        this.grid.print();
        break;
    }

  }
}
