import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommonVariable } from '../common/common.variable';
import { Router } from '@angular/router';
import { UrlConstant } from '../common/url.constants';
import { User } from '../domains/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private _httpClient: HttpClient, private _router: Router) { }
  private getHeader(): HttpHeaders {
    var dataUser = localStorage.getItem(CommonVariable.USER);

    if (dataUser == null) {
      this._router.navigate([UrlConstant.LOGIN])
      throw new Error("User not authenticated");
    }
    var user = JSON.parse(dataUser) as User

    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${user.access_Token}`
    })
  }

  get<T>(url: string): Observable<any> {
    const header = this.getHeader();
    return this._httpClient.get<T>(UrlConstant.BASE_URL + url, { headers: header })
  }
  post<T>(url: string, data: any): Observable<T> {
    const headers = this.getHeader();
    return this._httpClient.post<T>(UrlConstant.BASE_URL + url, data, { headers });
  }

  // PUT method
  put<T>(url: string, data: any): Observable<T> {
    const headers = this.getHeader();
    return this._httpClient.put<T>(UrlConstant.BASE_URL + url, data, { headers });
  }

  // PATCH method
  patch<T>(url: string, data: any): Observable<T> {
    const headers = this.getHeader();
    return this._httpClient.patch<T>(UrlConstant.BASE_URL + url, data, { headers });
  }

  // DELETE method
  delete<T>(url: string, key: string, id: string): Observable<T> {
    const headers = this.getHeader();
    return this._httpClient.delete<T>(UrlConstant.BASE_URL + url + "/?" + key + "=" + id, { headers });
  }

  // POST method with image
  postImage<T>(url: string, image: File, additionalData?: any): Observable<T> {
    const formData: FormData = new FormData();
    formData.append('image', image, image.name);

    if (additionalData) {
      for (const key in additionalData) {
        if (additionalData.hasOwnProperty(key)) {
          formData.append(key, additionalData[key]);
        }
      }
    }

    const headers = this.getHeader();

    return this._httpClient.post<T>(UrlConstant.BASE_URL + url, formData, { headers });
  }

}
