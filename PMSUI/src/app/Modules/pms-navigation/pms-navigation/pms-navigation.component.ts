import { Component, ViewChild } from '@angular/core';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { SidebarComponent, NodeSelectEventArgs } from '@syncfusion/ej2-angular-navigations';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pms-navigation',
  templateUrl: './pms-navigation.component.html',
  styleUrls: ['./pms-navigation.component.css']
})
export class PmsNavigationComponent {
  title = 'sidebar';
  @ViewChild('sidebar')
  public sidebar: SidebarComponent;
  public type: 'Push';
  public target: 'content';
  @ViewChild('togglebtn')
  public togglebtn: ButtonComponent;
  public hierarchicalData: Object[] = [
    {
      id: 'profile', name: 'COMPANY',
      subChild: [
        { id: 'profile', name: 'PROFILE' },
        { id: 'employees', name: 'EMPLOYEES' },
        { id: 'products', name: 'PRODUCTS' }
      ]
    },
    {
      id: 'stock', name: 'STOCK',
      subChild: [
        { id: 'stock', name: 'STOCK' },
        { id: 'shipments', name: 'SHIPMENTS' },
        { id: 'critical-on-hand', name: 'CRITICAL-ON-HAND' }
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
      id: 'settings', name: 'SETTING', subChild: [
        { id: '44', name: 'USER MANAGMENT' },
        { id: '55', name: 'SYSTEM SETTINGS' }
      ]
    }

  ];
  public field: Object = { dataSource: this.hierarchicalData, id: 'id', text: 'name', child: 'subChild' };
  btnClick() {
    if (this.togglebtn.element.classList.contains('e-active')) {
      this.togglebtn.content = 'Open';
      this.sidebar.hide();
    } else {
      this.togglebtn.content = 'Close';
      this.sidebar.show();
    }
  }

  clickedNode(event: NodeSelectEventArgs) {
    console.log(event);
    const node = event.nodeData;
    if (!node.parentId) {
      this.router.navigate([`${node.id}`]);
    }
  }
  constructor(private router: Router) {

  }

}
