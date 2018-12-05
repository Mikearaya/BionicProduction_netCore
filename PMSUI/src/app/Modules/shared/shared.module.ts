

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
import { BionicDialogComponent } from './bionic-dialog/bionic-dialog.component';
import { DialogModule } from '@syncfusion/ej2-angular-popups';
import { TabModule } from '@syncfusion/ej2-angular-navigations';


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
    DocumentEditorAllModule,
    DialogModule
  ],
  declarations: [FormOptionsComponent, NotificationComponent, ToastComponent,  BionicDialogComponent],
  exports: [
    // angular
    ReactiveFormsModule,
    GridModule,
    TabModule,
    NotificationComponent,
    // syncfusion
    BionicDialogComponent,
    RadioButtonModule,
    FormOptionsComponent,
    ButtonModule,
    TextBoxModule,
    CommonModule,
    NumericTextBoxModule,
    DropDownListModule,
    DateTimePickerModule,
    SwitchModule,
    DatePickerModule,
    DialogModule

  ],
  providers: []

})
export class SharedModule { }
