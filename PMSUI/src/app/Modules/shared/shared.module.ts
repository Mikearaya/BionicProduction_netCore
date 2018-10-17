

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import { NumericTextBoxComponent, TextBoxModule } from '@syncfusion/ej2-angular-inputs';
import { RadioButtonModule, ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RadioButtonModule,
    ButtonModule,
    ReactiveFormsModule,
    TextBoxModule
  ],
  declarations: [FormOptionsComponent, NumericTextBoxComponent],
  exports: [ NumericTextBoxComponent, RadioButtonModule, FormOptionsComponent, ButtonModule, TextBoxModule,
    ReactiveFormsModule ],
  providers: []

})
export class SharedModule { }
