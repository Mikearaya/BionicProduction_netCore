

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import {
  GridModule, PageService, SortService, FilterService, GroupService,
  EditService, ResizeService
} from '@syncfusion/ej2-angular-grids';
import { NumericTextBoxComponent } from '@syncfusion/ej2-angular-inputs';
import { RadioButtonModule } from '@syncfusion/ej2-ng-buttons';

@NgModule({
  imports: [
    RadioButtonModule
  ],
  declarations: [ NumericTextBoxComponent],
  exports: [ NumericTextBoxComponent, RadioButtonModule ],
  providers: []

})
export class SharedModule { }
