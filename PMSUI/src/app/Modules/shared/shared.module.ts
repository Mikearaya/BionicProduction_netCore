

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import {
  GridModule, PageService, SortService, FilterService, GroupService,
  EditService, ResizeService
} from '@syncfusion/ej2-angular-grids';
import { NumericTextBoxComponent } from '@syncfusion/ej2-angular-inputs';

@NgModule({
  imports: [
  ],
  declarations: [ NumericTextBoxComponent],
  exports: [ NumericTextBoxComponent ],
  providers: []

})
export class SharedModule { }
