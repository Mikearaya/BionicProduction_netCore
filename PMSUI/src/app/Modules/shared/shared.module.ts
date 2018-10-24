

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import { NumericTextBoxComponent, TextBoxModule, NumericTextBoxModule } from '@syncfusion/ej2-angular-inputs';
import { RadioButtonModule, ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownListModule } from '@syncfusion/ej2-ng-dropdowns';
import { DateTimePickerModule } from '@syncfusion/ej2-angular-calendars';

@NgModule({
  imports: [
    CommonModule,
    RadioButtonModule,
    ButtonModule,
    ReactiveFormsModule,
    TextBoxModule,
    NumericTextBoxModule,
    ButtonModule,
    DropDownListModule,
    DateTimePickerModule,
  ],
  declarations: [FormOptionsComponent],
  exports: [RadioButtonModule, FormOptionsComponent, ButtonModule, TextBoxModule,
    NumericTextBoxModule,
    ButtonModule,
    DropDownListModule,
    DateTimePickerModule,
    ReactiveFormsModule],
  providers: []

})
export class SharedModule { }
