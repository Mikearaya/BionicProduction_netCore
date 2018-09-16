
import { NgModule } from '@angular/core';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerService } from './customer.service';
import { CustomerViewComponent } from './customer-view/customer-view.component';
import { PageService, SortService, FilterService, GroupService, ResizeService,
  ColumnChooserService, ColumnMenuService,
  ForeignKeyService, RowDDService, EditService, ExcelExportService, GridModule,
   ToolbarService, SearchService } from '@syncfusion/ej2-ng-grids';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
              CustomerRoutingModule,
              HttpClientModule,
            GridModule ],
  declarations: [CustomerFormComponent, CustomerViewComponent],
  exports: [CustomerFormComponent, CustomerViewComponent],
  providers: [CustomerService, PageService,
    SortService,
    FilterService,
    SearchService,
    GroupService,
ColumnChooserService,
ColumnMenuService,
ForeignKeyService,
RowDDService,
EditService,
ToolbarService,
ExcelExportService]

})
export class CustomerModule { }
