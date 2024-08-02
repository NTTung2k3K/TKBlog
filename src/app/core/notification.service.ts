import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private _notify: ToastrService) { }
  showSuccess(title: string, message: string) {
    this._notify.success(message, title);
  }
  showError(title: string, message: string) {
    this._notify.error(message, title);
  }
  showInfo(title: string, message: string) {
    this._notify.info(message, title);
  }
  showWarning(title: string, message: string) {
    this._notify.warning(message, title);
  }




}
