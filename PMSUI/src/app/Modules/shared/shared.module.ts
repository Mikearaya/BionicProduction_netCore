

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import { TextBoxModule, NumericTextBoxModule } from '@syncfusion/ej2-angular-inputs';
import { RadioButtonModule, ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { DateTimePickerModule } from '@syncfusion/ej2-angular-calendars';
import { GridModule } from '@syncfusion/ej2-angular-grids';

@NgModule({
  imports: [
    // angular
    CommonModule,
    ReactiveFormsModule,
    // syncfusion
    TextBoxModule,
    RadioButtonModule,
    ButtonModule,
    GridModule,
    NumericTextBoxModule,
    DropDownListModule,
    DateTimePickerModule,
  ],
  declarations: [FormOptionsComponent],
  exports: [
    // angular
    ReactiveFormsModule,
    GridModule,
    // syncfusion
    RadioButtonModule,
    FormOptionsComponent,
    ButtonModule,
    TextBoxModule,
    NumericTextBoxModule,
    DropDownListModule,
    DateTimePickerModule,

  ],
  providers: []

})
export class SharedModule { }
