import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataService } from '../../../core/data.service';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NewsComponent } from './news.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [NewsComponent],
  imports: [
    CommonModule, NzPaginationModule, RouterModule, FormsModule
  ],
  providers: [DataService],
})
export class NewsModule { }
