import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlConstant } from '../common/url.constants';
import { CommonVariable } from '../common/common.variable';
import { Router } from '@angular/router';
import { User } from '../domains/user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _httpClient: HttpClient, private _router: Router) { }

  login(username: string, password: string) {
    var data = {
      userName: username,
      password: password
    }
    this._httpClient.post(UrlConstant.BASE_URL + "/api/Staffs/LoginStaffWithResponse", data).subscribe(response => {
      console.log(response);
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
