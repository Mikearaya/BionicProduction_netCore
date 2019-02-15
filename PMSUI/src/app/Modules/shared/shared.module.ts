

import { NgModule } from '@angular/core';
import { FormOptionsComponent } from './form-options/form-options.component';
import { TextBoxModule, NumericTextBoxModule, ColorPickerModule } from '@syncfusion/ej2-angular-inputs';
import { RadioButtonModule, ButtonModule, SwitchModule, CheckBoxModule } from '@syncfusion/ej2-angular-buttons';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownListModule, MultiSelectModule } from '@syncfusion/ej2-angular-dropdowns';
import { DateTimePickerModule, DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import { GridModule } from '@syncfusion/ej2-angular-grids';
import { DocumentEditorAllModule } from '@syncfusion/ej2-angular-documenteditor';
import { NotificationComponent } from './notification/notification.component';
import { ToastComponent } from '@syncfusion/ej2-angular-notifications';
import { BionicDialogComponent } from './bionic-dialog/bionic-dialog.component';
import { DialogModule } from '@syncfusion/ej2-angular-popups';
import { TabModule, ToolbarModule, SidebarModule, TreeViewAllModule, MenuModule } from '@syncfusion/ej2-angular-navigations';
import { DocumentCreatorModule } from './document-creator/document-creator.module';
import { ListViewModule } from '@syncfusion/ej2-angular-lists';
import { BreadCrumbComponent } from './bread-crumb/bread-crumb.component';
import { RouterModule } from '@angular/router';

import { PageTitleComponent } from './page-title/page-title.component';
import { PageIdentityComponent } from './page-itentity/page-identity.component';


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
    TreeViewAllModule,
    DocumentEditorAllModule,
    DialogModule,
    DocumentCreatorModule,
    RouterModule

  ],
  declarations: [FormOptionsComponent,
    NotificationComponent,
    ToastComponent,
    BionicDialogComponent,
    PageIdentityComponent, PageTitleComponent, BreadCrumbComponent],
  exports: [
    // angular
    ReactiveFormsModule,
    DocumentCreatorModule,
    MenuModule,
    MultiSelectModule,
    ColorPickerModule,
    GridModule,
    TabModule,
    CheckBoxModule,
    NotificationComponent,
    ToolbarModule,
    PageIdentityComponent,
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
    DialogModule,
    SidebarModule,
    ListViewModule,
    TreeViewAllModule

  ],
  providers: []

})
export class SharedModule { }
