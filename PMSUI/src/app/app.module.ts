/*
 * @CreateTime: Dec 3, 2018 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 1:51 AM
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
import { RoutingFormComponent } from './Modules/feature/work-order/production-routing/routing-form/routing-form.component';
import { RoutingViewComponent } from './Modules/feature/work-order/production-routing/routing-view/routing-view.component';



@NgModule({
  declarations: [
    AppComponent,
    RoutingFormComponent,
    RoutingViewComponent
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
