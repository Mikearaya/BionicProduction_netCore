
import { NgModule } from '@angular/core';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerService } from './customer.service';
import { CustomerViewComponent } from './customer-view/customer-view.component';

import {
    GridModule, PageService, SortService, FilterService, SearchService, GroupService,
    ColumnChooserService, ColumnMenuService, ForeignKeyService, RowDDService, EditService,
    ToolbarService, ExcelExportService
} from '@syncfusion/ej2-angular-grids';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [
        // application
        CustomerRoutingModule,
        // angular
        ReactiveFormsModule,
        CommonModule,
        // syncfusion
        GridModule,
    ],
    declarations: [
        // application
        CustomerFormComponent,
        CustomerViewComponent],
    providers: [
        // application
        CustomerService,
        // syncfusion
    ],
    exports: []

})
export class CustomerModule { }
