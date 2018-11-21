import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from './Modules/core/core.module';
import { CoreHttpInterceptor } from './Modules/core/core-http-interceptor';
import { GridModule, PdfExportService } from '@syncfusion/ej2-angular-grids';
import { StatCardComponent } from './Modules/feature/dashboard/stat-card/stat-card.component';
import { ProductionStatusChartComponent } from './Modules/feature/bionic-charts/production-status-chart/production-status-chart.component';


@NgModule({
  declarations: [
    AppComponent,
    ProductionStatusChartComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    GridModule

  ],
  providers: [
    PdfExportService,
    { provide: 'BASE_URL', useValue: 'http://localhost:5000/api' },
      {provide: HTTP_INTERCEPTORS, useClass: CoreHttpInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
