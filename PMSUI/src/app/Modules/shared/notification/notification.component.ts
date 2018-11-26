import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastComponent } from '@syncfusion/ej2-angular-notifications';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {
  @ViewChild('element') element: ToastComponent;
  public position = { X: 'Right', Y: 'Top' };
  public toasts = [
    { title: 'Warning !', content: '', cssClass: 'e-toast-warning' },
    { title: 'Success !', content: '', cssClass: 'e-toast-success' },
    { title: 'Error !', content: '', cssClass: 'e-toast-danger' },
    { title: 'Information !', content: '', cssClass: 'e-toast-info' }];


  constructor() { }

  ngOnInit() {
    this.element.showCloseButton = true;
  }

  showMessage(title: string, message: string, type: string): void {
    let toastIndex = 0;
    this.element.title = title;
    this.element.content = message;
    switch (type.toUpperCase()) {
      case 'SUCCESS':
        toastIndex = 1;

        break;
      case 'WARNING':
        toastIndex = 0;
        break;
      case 'ERROR':
        toastIndex = 2;
        break;
      case 'INFORMATION':
        toastIndex = 3;
        break;
      default:
        toastIndex = 3;
        break;
    }

    this.toasts[toastIndex].content = message;
    this.toastShow(toastIndex);
  }

  toastShow(index: number) {
    setTimeout(
      () => {
        this.element.show(this.toasts[index]);
      }, 700);
  }
}
