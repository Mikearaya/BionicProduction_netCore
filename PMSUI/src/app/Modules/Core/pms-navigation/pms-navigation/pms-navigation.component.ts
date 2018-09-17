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
  public type: 'push';
  public target: 'content';
  @ViewChild('togglebtn')
  public togglebtn: ButtonComponent;
  public hierarchicalData: Object[] = [
    {
      id: 'oganizations', name: 'ORGANIZATION',
      subChild: [
        {
          id: 'employees', name: 'EMPLOYEES'
        },
        {
          id: 'customers', name: 'CUSTOMERS'
        },
        {
          id: 'products', name: 'PRODUCTS'
        }
      ]
    },
    {
      id: 'workorders', name: 'PRODUCTION'
    },
    {
      id: '05', name: 'Sales'
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
    console.log(event.nodeData);
    const node = event.nodeData;
    if (node.parentId !== null) {
      this.router.navigate([`home/${node.id}`]);
    }
  }
  constructor(private router: Router) {

  }

}
