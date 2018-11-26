

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import { TextBoxModule, NumericTextBoxModule } from '@syncfusion/ej2-angular-inputs';
import { RadioButtonModule, ButtonModule, SwitchModule } from '@syncfusion/ej2-angular-buttons';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { DateTimePickerModule, DatePickerModule, DatePickerAllModule } from '@syncfusion/ej2-angular-calendars';
import { GridModule } from '@syncfusion/ej2-angular-grids';
import { DocumentEditorAllModule } from '@syncfusion/ej2-angular-documenteditor';
import { NotificationComponent } from './notification/notification.component';
import { ToastComponent } from '@syncfusion/ej2-angular-notifications';


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
    SwitchModule,
    DatePickerModule,
    DocumentEditorAllModule
  ],
  declarations: [FormOptionsComponent, NotificationComponent, ToastComponent],
  exports: [
    // angular
    ReactiveFormsModule,
    GridModule,
    NotificationComponent,
    // syncfusion
    RadioButtonModule,
    FormOptionsComponent,
    ButtonModule,
    TextBoxModule,
    CommonModule,
    NumericTextBoxModule,
    DropDownListModule,
    DateTimePickerModule,
    SwitchModule,
    DatePickerModule

  ],
  providers: []

})
export class SharedModule { }
