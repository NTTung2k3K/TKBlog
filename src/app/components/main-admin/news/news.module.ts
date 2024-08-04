import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataService } from '../../../core/data.service';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NewsComponent } from './news.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { EditorModule, TINYMCE_SCRIPT_SRC } from '@tinymce/tinymce-angular';
import { AngularFireModule } from '@angular/fire/compat';
import { AngularFireStorageModule } from '@angular/fire/compat/storage';
import { FirebaseEnvirontment } from '../../../common/firebase.environment';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';
import { NzSpinModule } from 'ng-zorro-antd/spin';



@NgModule({
  declarations: [NewsComponent],
  imports: [
    CommonModule, NzPaginationModule, RouterModule, FormsModule, NzModalModule, ReactiveFormsModule, NzSwitchModule
    , NzUploadModule, EditorModule, AngularFireModule.initializeApp(FirebaseEnvirontment.environment.firebase),
    AngularFireStorageModule, NzPopconfirmModule, NzSpinModule
  ],
  providers: [DataService, { provide: TINYMCE_SCRIPT_SRC, useValue: 'tinymce/tinymce.min.js' }],
})
export class NewsModule { }
