import { Component, ViewChild, OnInit, ElementRef } from '@angular/core';
import { ButtonComponent } from '@syncfusion/ej2-angular-buttons';
import { SidebarComponent, NodeSelectEventArgs, ItemDirective } from '@syncfusion/ej2-angular-navigations';
import { Router, ActivatedRoute } from '@angular/router';
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
      id: 'home', name: 'Stock',
      subChild: [
        { id: 'stocks', name: 'Stock' },
        { id: 'stocks/shipments', name: 'Shipments' },
        { id: 'stocks/stock-lots', name: 'Stock Lots' },
        { id: 'stocks/inventory', name: 'Inventory' },
        { id: 'stocks/low-stock', name: 'Critical-On-Hand' },
        { id: 'stocks/write-offs', name: 'Write-offs' },
        { id: 'stocks/stock-lots/movements', name: 'Stock Movement' },
        {
          id: 'stocks/settings', name: 'Stock Settings ',
          subChild: [
            { id: 'stocks/settings/product-groups', name: 'Product Groups' },
            { id: 'stocks/settings/unit-of-measure', name: 'Unit of Measurements' },
            { id: 'boms', name: 'Bill of Material' },
            { id: 'stocks/settings/storages', name: 'Storage Locations' }
          ]
        },
      ]
    },
    {
      id: '2', name: 'Production',
      subChild: [
        { id: 'productions', name: 'Manufacture Orders' },
        { id: 'productions/pending', name: 'Production Requests' },
        { id: 'productions/completed', name: 'Completed Productions' },
        { id: 'productions/schedules', name: 'Production Schedules' },
        { id: 'productions/workstations/stations', name: 'Work Stations' },
        { id: 'productions/workstations', name: 'Work Stations Groups' },
        { id: 'productions/boms', name: 'Bills of Material' },
        { id: 'productions/routings', name: 'Routings' },

      ]
    },
    {
      id: 'crm', name: 'Sales',
      subChild: [
        { id: 'crm/customers', name: 'CUSTOMERS' },
        { id: 'crm/customer-orders', name: 'CUSTOMER ORDERS' },
        { id: 'crm/invoices', name: 'INVOICES' }
      ]
    },
    {
      id: 'procurments', name: 'Procurments',
      subChild: [
        { id: 'procurments/purchase-orders', name: 'Purchase Orders' },
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

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute) { }


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
