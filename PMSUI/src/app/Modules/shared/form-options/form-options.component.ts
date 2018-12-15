/*
 * @CreateTime: Oct 10, 2018 12:25 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 1, 2018 1:34 AM
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
  @Input('submitButtonText') submitButtonText: String = 'Submit';
  @Input('cancelButtonText') cancelButtonText: String = 'Back';

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
