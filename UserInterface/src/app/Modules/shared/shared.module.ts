import { MatDialogModule } from '@angular/material/dialog';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomDatePickerModule } from './custom-date-picker/custom-date-picker.module';
import { LayoutModule } from '@angular/cdk/layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatToolbarModule, MatButtonModule, MatDividerModule, MatSidenavModule,
  MatIconModule, MatListModule, MatGridListModule, MatMenuModule,
  MatExpansionModule, MatCardModule, MatFormFieldModule, MatSelectModule, MatInputModule,
  MatCheckboxModule, MatTableModule, MatProgressSpinnerModule, MatPaginatorModule,
  MatSortModule, MatSlideToggleModule, MatAutocompleteModule, MatDatepickerModule, MatNativeDateModule, MatButtonToggleModule
} from '@angular/material';
import { FormOptionsComponent } from './form-options/form-options.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { GridModule, PageService, SortService, FilterService, GroupService, ResizeService, EditService } from '@syncfusion/ej2-ng-grids';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  imports: [
    CommonModule,
    GridModule,
    MatButtonModule,
    BrowserModule,
  ],
  declarations: [FormOptionsComponent],
  exports: [CommonModule,
    ReactiveFormsModule,
    GridModule,
    LayoutModule,
    BrowserModule,
    BrowserAnimationsModule,

    CustomDatePickerModule,
    FormOptionsComponent,

    MatTableModule,
    MatDialogModule,
    MatSortModule,
    MatCardModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatInputModule,
    MatCheckboxModule,
    MatSelectModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonToggleModule,
    MatProgressSpinnerModule,
    MatToolbarModule,
    MatDividerModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    MatMenuModule,
    MatExpansionModule,
    MatSlideToggleModule,
  ],
  providers: [PageService,
    SortService,
    FilterService,
    GroupService,
    EditService,
  ResizeService]

})
export class SharedModule { }
