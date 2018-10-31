/*
 * @CreateTime: Sep 8, 2018 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 1, 2018 1:37 AM
 * @Description: Products Module Class
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsAPIService } from './products-api.service';

import { ProductsViewComponent } from './products-view/products-view.component';
import {
  GridModule

} from '@syncfusion/ej2-angular-grids';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    // angular
    CommonModule,
    ReactiveFormsModule,
    // application
    ProductsRoutingModule,
    // syncfusion
    GridModule
  ],
  declarations: [ProductsViewComponent],
  providers: [
    // application
    ProductsAPIService,
    // syncfusion
  ]
})
export class ProductsModule { }
