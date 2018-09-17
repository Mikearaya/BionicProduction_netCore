

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormOptionsComponent } from './form-options/form-options.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { BrowserModule } from '@angular/platform-browser';
import {
  GridModule, PageService, SortService, FilterService, GroupService,
  EditService, ResizeService
} from '@syncfusion/ej2-angular-grids';

@NgModule({
  imports: [
    CommonModule,
    GridModule,
  ],
  declarations: [FormOptionsComponent],
  exports: [CommonModule,
    ReactiveFormsModule,
    GridModule,
    BrowserModule,
    BrowserAnimationsModule,

    FormOptionsComponent,

    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [PageService,
    SortService,
    FilterService,
    GroupService,
    EditService,
    ResizeService]

})
export class SharedModule { }
