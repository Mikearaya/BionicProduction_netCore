import { Component, ViewEncapsulation, Inject, ViewChild } from '@angular/core';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { SidebarComponent, TreeViewComponent, NodeClickEventArgs, NodeSelectEventArgs } from '@syncfusion/ej2-angular-navigations';
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
     id: '1', name: 'COMPANY',
      subChild: [
        { id: 'profile', name: 'PROFILE' },
        { id: 'employees', name: 'EMPLOYEES' },
        { id: 'customers', name: 'CUSTOMERS' },
        { id: 'products', name: 'PRODUCTS' }
      ]
    },
    {
    id: '2',  name: 'PRODUCTION',
      subChild: [
        { id: 'workorders', name: 'WORK ORDER' },
        { id: 'workorders/completed', name: 'ADD FINISHED ORDERS' }
      ]
    },
    { id: 'stock', name: 'STOCK' },
    { id: 'reports', name: 'REPORT'},
    { id: 'settings', name: 'SETTING'}

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
