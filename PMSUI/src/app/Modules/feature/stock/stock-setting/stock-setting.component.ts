import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { SidebarComponent } from '@syncfusion/ej2-angular-navigations';
import { ButtonComponent } from '@syncfusion/ej2-angular-buttons';

@Component({
  selector: 'app-stock-setting',
  templateUrl: './stock-setting.component.html',
  styleUrls: ['./stock-setting.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class StockSettingComponent implements OnInit {

  @ViewChild('sidebar')
  public sidebar: SidebarComponent;
  public type = 'Push';
  public target = 'title';

  @ViewChild('togglebtn')
  public togglebtn: ButtonComponent;

  public data = [
    { name: 'Product Groups', url: '/stocks/settings/product-groups' },
    { name: 'Unit of Measurments', url: '/stocks/settings/unit-of-measure' },
    { name: 'Storage locations', url: '/stocks/settings/storages' },
  ];
  ngOnInit(): void {

  }
  btnClick() {
    if (this.togglebtn.element.classList.contains('e-active')) {
      this.togglebtn.content = 'Open';
      this.sidebar.hide();
    } else {
      this.togglebtn.content = 'Close';
      this.sidebar.show();
    }
  }
  closeClick() {
    this.sidebar.hide();
    this.togglebtn.element.classList.remove('e-active');
    this.togglebtn.content = 'Open';
  }
  public changeHandler(args: any): void {
    this.sidebar.position = (args.event.target.id === 'left') ? 'Left' : 'Right';
  }


}
