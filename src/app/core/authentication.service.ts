import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlConstant } from '../common/url.constants';
import { CommonVariable } from '../common/common.variable';
import { Router } from '@angular/router';
import { User } from '../domains/user';
import { SystemConstant } from '../common/system.constants';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _httpClient: HttpClient, private _router: Router, private _notifiService: NotificationService) { }

  login(username: string, password: string) {
    var data = {
      userName: username,
      password: password
    }
    this._httpClient.post<any>(UrlConstant.BASE_URL + "/api/Staffs/LoginStaffWithResponse", data).subscribe(response => {
      const user = new User(response.resultObj.staffId, response.resultObj.fullName, response.resultObj.email, response.resultObj.image, response.resultObj.access_Token);
      localStorage.setItem(CommonVariable.USER, JSON.stringify(user))
      this._router.navigate([UrlConstant.MAIN_ADMIN])
    }, error => {
      this._notifiService.showError("Error Credential", "Username or password is invalid!");
    })
  }

  logout() {

    localStorage.removeItem(CommonVariable.USER);
    this._router.navigate([UrlConstant.LOGIN])
  }

  getUser(): User {
    var dataUser = localStorage.getItem(CommonVariable.USER);

    if (dataUser == null) {
      this._router.navigate([UrlConstant.LOGIN])
      throw new Error("User not authenticated");
    }
    var user = JSON.parse(dataUser) as User
    return user;
  }
}
