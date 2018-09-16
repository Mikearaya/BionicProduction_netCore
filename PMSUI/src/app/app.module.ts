import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { PmsNavigationModule } from './Modules/Core/pms-navigation/pms-navigation.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PmsNavigationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
