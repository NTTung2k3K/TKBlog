import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../core/data.service';
import { CommonVariable } from '../../../common/common.variable';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NzUploadChangeParam } from 'ng-zorro-antd/upload';
import { NotificationService } from '../../../core/notification.service';
import { EditorComponent } from '@tinymce/tinymce-angular';
import { finalize, last } from 'rxjs/operators';
import { AngularFireStorage } from '@angular/fire/compat/storage';
import { AuthenticationService } from '../../../core/authentication.service';
import { SystemConstant } from '../../../common/system.constants';
import { log } from 'ng-zorro-antd/core/logger';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrl: './news.component.css'
})
export class NewsComponent implements OnInit {

  pageIndex: number = 1;
  pageSize: number = -1;
  totalNews: number = -1;
  keyword: string = "";
  newsData: any = [];

  source: string = '';
  title = 'images-tinymce';
  config: EditorComponent['init'] = {
    base_url: "/tinymce",
    suffix: ".min",
    plugins: "lists link image table wordcount",
    toolbar: "undo redo | formatselect | bold italic | alignleft aligncenter alignright | bullist numlist outdent indent | link image",
    automatic_uploads: true,

    images_upload_handler: (blobInfo) => {
      const file = blobInfo.blob();
      const filePath = `${Date.now()}-${blobInfo.filename()}`;
      const ref = this.storage.ref(filePath);
      const task = this.storage.upload(filePath, file);
      const promise = new Promise<string>((resolve, reject) => {
        task
          .snapshotChanges()
          .pipe(
            finalize(() =>
              ref
                .getDownloadURL()
                .pipe(last())
                .subscribe((url: any) => {
                  resolve(url);
                })
            )
          )
          .subscribe((_) => {
            // do nothing
          });
      });
      return promise;
    },
  };




  constructor(private _authenService: AuthenticationService, private _dataService: DataService, private _notificationService: NotificationService, private storage: AngularFireStorage) { }


  ngOnInit(): void {
    this.LoadData()
  }
  public LoadData() {
    this._dataService.get(`/api/News/View?Keyword=${this.keyword}&pageIndex=${this.pageIndex}`).subscribe(response => {
      this.newsData = response.resultObj.items;
      this.pageIndex = response.resultObj.pageIndex;
      this.pageSize = response.resultObj.pageSize;
      this.totalNews = response.resultObj.totalRecords;
    })
  }
  onPageIndexChange(pageIndex: number) {
    this.pageIndex = pageIndex;
    this.LoadData();
  }

  // Handle Create/Update
  isVisible = false;


  showModal(): void {
    this.isVisible = true;
  }
  handleChange(info: NzUploadChangeParam): void {
    if (info.file.status !== 'uploading') {
      console.log(info.file, info.fileList);
    }
    if (info.file.status === 'done') {
      this._notificationService.showSuccess('Success', `${info.file.name} file uploaded successfully`);
    } else if (info.file.status === 'error') {
      this._notificationService.showError('Error', `${info.file.name} file upload failed.`);
    }
  }

  handleCancel(): void {
    this.isVisible = false;
  }
  createUpdateForm: FormGroup = new FormGroup({
    NewsId: new FormControl(),
    NewName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(70)]),
    Title: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(70)]),
    Image: new FormControl(null, [Validators.required]),
    Description: new FormControl(''),
    Status: new FormControl(''),
  });
  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.createUpdateForm.patchValue({
        Image: file
      })
    }
  }
  onCreateUpdate() {
    if (!this.createUpdateForm.valid) return;


    const formData = new FormData();
    formData.append('NewName', this.createUpdateForm.value.NewName);
    formData.append('Title', this.createUpdateForm.value.Title);
    formData.append('Image', this.createUpdateForm.get('Image')?.value);
    formData.append('Description', this.createUpdateForm.value.Description);
    formData.append('Status', this.createUpdateForm.value.Status);
    formData.append('WriterId', this._authenService.getUser().staffId);

    if (this.createUpdateForm.value.NewsId == null) {
      this._dataService.postWithImage('/api/News/Create', formData)
        .subscribe((response: any) => {
          if (response.isSuccessed) {
            this.LoadData();
            this.createUpdateForm.reset();
            this._notificationService.showSuccess("Success", SystemConstant.CREATE_SUCCESSFUL);
          } else {
            this._notificationService.showWarning("Warning", response.message)
          }
        }, error => {
          this._notificationService.showError("Error", error.message)
        })
    } else {
      formData.append("NewsId", this.createUpdateForm.value.NewsId);
      this._dataService.putWithImage('/api/News/Update', formData)
        .subscribe((response: any) => {
          if (response.isSuccessed) {
            this.LoadData();
            this.createUpdateForm.reset();
            this._notificationService.showSuccess("Success", SystemConstant.CREATE_SUCCESSFUL);
          } else {
            this._notificationService.showWarning("Warning", response.message)
          }
        }, error => {
          this._notificationService.showError("Error", error.message)
        })
    }



    this.isVisible = false;
  }
  onEditDetail(NewsId: any) {
    this._dataService.get('/api/News/GetById?NewsId=' + NewsId).subscribe((response: any) => {
      console.log(response);
      this.createUpdateForm.setValue({
        NewsId: response.resultObj.newsId,
        NewName: response.resultObj.newName,
        Title: response.resultObj.title,
        Image: response.resultObj.image,
        Description: response.resultObj.description,
        Status: response.resultObj.status,
      })
      this.showModal();
    }, error => {
      this._notificationService.showError("Error", error.message)
    })
  }
}
