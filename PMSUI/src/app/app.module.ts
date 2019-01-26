/*
 * @CreateTime: Dec 3, 2018 11:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 26, 2019 8:26 PM
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
import { EntryComponent } from './entry/entry.component';
import { ToolbarModule } from '@syncfusion/ej2-angular-navigations';
import { ListViewModule } from '@syncfusion/ej2-angular-lists';




@NgModule({
  declarations: [
    AppComponent,
    EntryComponent,
  ],
  imports: [
    BrowserModule,
    CoreModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToolbarModule,
    AppRoutingModule,
    ListViewModule,

  ],
  providers: [
    { provide: 'BASE_URL', useValue: 'http://localhost:5000/api' },
    { provide: HTTP_INTERCEPTORS, useClass: CoreHttpInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
