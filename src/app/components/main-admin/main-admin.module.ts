import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainAdminComponent } from './main-admin.component';
import { NewsComponent } from './news/news.component';
import { AppRoutingModule } from '../../app-routing.module';



@NgModule({
  declarations: [
    MainAdminComponent,
    NewsComponent
  ],
  imports: [
    CommonModule, AppRoutingModule
  ]
})
export class MainAdminModule { }
