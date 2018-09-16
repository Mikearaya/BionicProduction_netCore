import { Component, ViewEncapsulation, Inject, ViewChild } from '@angular/core';
import { ButtonComponent } from '@syncfusion/ej2-ng-buttons';
import { SidebarComponent, TreeViewComponent } from '@syncfusion/ej2-angular-navigations';

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
      id: '1', name: 'ORGANIZATION',
      subChild: [
        {
          id: '01-02', name: 'Employees', navigteUrl: 'employees'
        },
        {
          id: '01-03', name: 'Clients', navigteUrl: 'customers'
        }
      ]
    },
    {
      id: '02', name: 'Productions', navigateUrl: 'workorders'
    },
    {
      id: '03', name: 'REPORTS', navigateUrl: 'products'
    },
    {
      id: '05', name: 'Sales', navigateUrl: 'salses'
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
  constructor() { }

}
