/*
 * @CreateTime: Oct 10, 2018 12:25 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 1, 2018 1:34 AM
 * @Description: Modify Here, Please
 */
import { Location } from '@angular/common';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';



@Component({
  selector: 'app-form-options',
  templateUrl: './form-options.component.html',
  styleUrls: ['./form-options.component.css']
})
export class FormOptionsComponent implements OnInit {

  @Input() isSelfContained: Boolean;
  @Input() isUpdate: Boolean;
  @Input() submitDisabled: Boolean;
  @Input() cancelDisabled: Boolean;
  @Input() submitButtonText: String = 'Submit';
  @Input() cancelButtonText: String = 'Back';
  @Input() showDelete: Boolean;
  @Output() deleted = new EventEmitter<boolean>();

  delete() {
    this.deleted.emit(true);
  }

  constructor(private location: Location) {
    this.cancelDisabled = false;
    this.submitDisabled = false;
    this.isSelfContained = true;
    this.isSelfContained = true;
    this.isUpdate = false;
    this.showDelete = false;
  }

  ngOnInit() {
  }

  cancel() {
    this.location.back();
  }


}
