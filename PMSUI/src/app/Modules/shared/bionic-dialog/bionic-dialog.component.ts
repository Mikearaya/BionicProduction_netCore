/*
 * @CreateTime: Nov 28, 2018 4:34 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 28, 2018 4:36 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { EmitType } from '@syncfusion/ej2-base';

@Component({
  selector: 'app-bionic-dialog',
  templateUrl: './bionic-dialog.component.html',
  styleUrls: ['./bionic-dialog.component.css']
})
export class BionicDialogComponent implements OnInit {

  @ViewChild('ejDialog') ejDialog: DialogComponent;
  @ViewChild('container', { read: ElementRef }) container: ElementRef;
  @Input('modalContent')
  modalContent: string = 'Hello';

  ngOnInit() {
    this.initilaizeTarget();
  }


  public initilaizeTarget: EmitType<object> = () => {

  }


  public onOpenDialog = function (event: any): void {
    this.ejDialog.show();
  };

}
