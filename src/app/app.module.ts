import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginAdminComponent } from './components/login-admin/login-admin.component';
import { AuthenticationService } from './core/authentication.service';
import { DataService } from './core/data.service';
import { NotificationService } from './core/notification.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainAdminComponent } from './components/main-admin/main-admin.component';
import { MainAdminModule } from './components/main-admin/main-admin.module';
import { LoginAdminModule } from './components/login-admin/login-admin.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LoginAdminComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, BrowserAnimationsModule, MainAdminModule, LoginAdminModule, ReactiveFormsModule, HttpClientModule, ToastrModule.forRoot()
  ],
  providers: [AuthenticationService, DataService, NotificationService, ToastrService],
  bootstrap: [AppComponent]
})
export class AppModule { }
