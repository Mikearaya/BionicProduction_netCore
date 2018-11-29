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
      id: 'stocks', name: 'STOCK',
      subChild: [
        { id: 'stocks', name: 'Stock' },
        { id: 'products', name: 'Products' },
        { id: 'shipments', name: 'Shipments' },
        { id: 'stock/low-stock', name: 'Critical-On-Hand' },
        { id: 'stock/settings', name: 'Stock Settings ',
      subChild: [
        { id: 'stock/product-groups', name: 'Product Groups' },
        { id: 'stock/unit-of-measures', name: 'Unit of Measurements' },
      ] },
      ]
    },
    {
      id: '2', name: 'PRODUCTION',
      subChild: [
        { id: 'workorders', name: 'MANUFACTURE ORDERS' },
        { id: 'workorders/pending', name: 'PRODUCTION REQUESTS' },
        { id: 'workorders/completed', name: 'COMPLATED PRODUCTION' }
      ]
    },
    {
      id: '345', name: 'SALES',
      subChild: [
        { id: 'customers', name: 'CUSTOMERS' },
        { id: 'sales', name: 'CUSTOMER ORDERS' },
        { id: 'invoices', name: 'INVOICES' }
      ]
    },

    {
      id: 'reports', name: 'REPORT', subChild: [
        { id: '22', name: 'PRODUCTION REPORTS' },
        { id: '33', name: 'SALES REPORTS' }
      ]
    },
    {
      id: 'profile', name: 'SETTINGS',
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
