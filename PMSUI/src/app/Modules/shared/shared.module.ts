

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import { NumericTextBoxComponent } from '@syncfusion/ej2-angular-inputs';
import { RadioButtonModule, ButtonModule } from '@syncfusion/ej2-ng-buttons';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    RadioButtonModule,
    ButtonModule,
  ],
  declarations: [FormOptionsComponent, NumericTextBoxComponent],
  exports: [ NumericTextBoxComponent, RadioButtonModule, FormOptionsComponent, ButtonModule ],
  providers: []

})
export class SharedModule { }
