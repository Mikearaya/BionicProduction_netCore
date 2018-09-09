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
