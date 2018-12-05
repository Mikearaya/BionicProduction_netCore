/*
 * @CreateTime: Dec 3, 2018 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 11:10 PM
 * @Description: Modify Here, Please
 */
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from './Modules/core/core.module';
import { CoreHttpInterceptor } from './Modules/core/core-http-interceptor';
import { BomFormComponent } from './Modules/feature/stock/bom/bom-form/bom-form.component';
import { BomViewComponent } from './Modules/feature/stock/bom/bom-view/bom-view.component';





@NgModule({
  declarations: [
    AppComponent,
    BomFormComponent,
    BomViewComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,

  ],
  providers: [
    { provide: 'BASE_URL', useValue: 'http://localhost:5000/api' },
    { provide: HTTP_INTERCEPTORS, useClass: CoreHttpInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
