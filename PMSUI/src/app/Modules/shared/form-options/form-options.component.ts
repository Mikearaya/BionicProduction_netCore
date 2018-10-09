/*
 * @CreateTime: Oct 10, 2018 12:25 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 10, 2018 12:25 AM
 * @Description: Modify Here, Please
 */
import { Location } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';



@Component({
  selector: 'app-form-options',
  templateUrl: './form-options.component.html',
  styleUrls: ['./form-options.component.css']
})
export class FormOptionsComponent implements OnInit {

@Input('isSelfContained') isSelfContained: Boolean;
@Input('submitDisabled') submitDisabled: Boolean;
@Input('cancelDisabled') cancelDisabled: Boolean;

  constructor(private location: Location) {
    this.cancelDisabled = false;
    this.submitDisabled = false;
    this.isSelfContained = true;
}

  ngOnInit() {
  }

  cancel() {
    this.location.back();
  }


}
