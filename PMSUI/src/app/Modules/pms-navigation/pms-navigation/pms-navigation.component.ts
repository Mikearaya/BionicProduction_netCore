import { Component, ViewChild, OnInit, ElementRef } from '@angular/core';
import { ButtonComponent } from '@syncfusion/ej2-angular-buttons';
import { SidebarComponent, NodeSelectEventArgs, ItemDirective } from '@syncfusion/ej2-angular-navigations';
import { Router } from '@angular/router';
import { EmitType } from '@syncfusion/ej2-base';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { BionicDialogComponent } from '../../shared/bionic-dialog/bionic-dialog.component';

@Component({
  selector: 'app-pms-navigation',
  templateUrl: './pms-navigation.component.html',
  styleUrls: ['./pms-navigation.component.css']
})
export class PmsNavigationComponent {

  @ViewChild('dialog')
  public dialog: BionicDialogComponent;
  title = 'sidebar';
  @ViewChild('sidebar')
  public sidebar: SidebarComponent;
  public type: 'Push';
  public open = 'Close';
  public target: 'content';
  @ViewChild('togglebtn')
  public togglebtn: ItemDirective;

  public hierarchicalData: Object[] = [
    {
      id: 'dashboard', name: 'DASHBOARD'
    },
    {
      id: 'stocks', name: 'Stock',
      subChild: [
        { id: 'stocks', name: 'Stock' },
        { id: 'shipments', name: 'Shipments' },
        { id: 'inventory/batchs', name: 'Stock Batchs' },
        { id: 'stocks/stock-count', name: 'Inventory Count' },
        { id: 'stocks/low-stock', name: 'Critical-On-Hand' },
        { id: 'inventory/write-offs', name: 'Write-offs' },
        { id: 'stocks/stock-movement', name: 'Stock Movement' },
        {
          id: 'stocks/settings', name: 'Stock Settings ',
          subChild: [
            { id: 'stocks/product-groups', name: 'Product Groups' },
            { id: 'unit-of-measure', name: 'Unit of Measurements' },
            { id: 'boms', name: 'Bill of Material' },
            { id: 'storages', name: 'Storage Locations' }
          ]
        },
      ]
    },
    {
      id: '2', name: 'Production',
      subChild: [
        { id: 'workorders', name: 'Manufacture Orders' },
        { id: 'workorders/pending', name: 'Production Requests' },
        { id: 'workorders/completed', name: 'Completed Productions' },
        { id: 'schedules', name: 'Production Schedules' },
        { id: 'work-stations/stations', name: 'Work Stations' },
        { id: 'work-stations', name: 'Work Stations Groups' },
        { id: 'boms', name: 'Bills of Material' },
        { id: 'routings', name: 'Routings' },

      ]
    },
    {
      id: '345', name: 'Sales',
      subChild: [
        { id: 'customers', name: 'CUSTOMERS' },
        { id: 'sales', name: 'CUSTOMER ORDERS' },
        { id: 'invoices', name: 'INVOICES' }
      ]
    },
    {
      id: 'procurments', name: 'Procurments',
      subChild: [
        { id: 'procurments', name: 'Purchase Orders' },
        { id: 'procurments/vendors', name: 'vendors' },
        { id: 'procurments/critical-on-hand', name: 'Critical Stock' },
        { id: 'procurments/requirments', name: 'Requirments' }
      ]
    },

    {
      id: 'reports', name: 'Reports', subChild: [
        { id: '22', name: 'PRODUCTION REPORTS' },
        { id: '33', name: 'SALES REPORTS' }
      ]
    },
    {
      id: 'profile', name: 'Settings',
      subChild: [
        { id: 'profile', name: 'PROFILE' },
        { id: 'employees', name: 'EMPLOYEES' }

      ]
    }


  ];

  public field: Object = { dataSource: this.hierarchicalData, id: 'id', text: 'name', child: 'subChild', routerLink: 'route' };

  constructor(private router: Router) { }


  btnClick() {

    if (this.sidebar.isOpen) {
      this.open = 'Open';

      this.sidebar.hide();
    } else {
      this.togglebtn.text = 'Open';
      this.open = 'Close';
      this.sidebar.show();
    }
  }

  clickedNode(event: NodeSelectEventArgs) {
    const node = event.nodeData;

    if (!node.parentId) {
      this.router.navigate([`${node.id}`]);
    }


  }

}
