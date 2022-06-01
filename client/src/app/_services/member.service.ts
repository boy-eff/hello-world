import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserInfo } from '../_models/user-info';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getMemberByUsername(username: string): Observable<UserInfo> {
    return this.http.get<UserInfo>(this.baseUrl + "users/" + username);
  }

  getUsers(): Observable<UserInfo[]> {
    return this.http.get<UserInfo[]>(this.baseUrl + "users");
  }

  uploadPhoto(photo: File)
  {
    let formData = new FormData();
    formData.append("file", photo);
    return this.http.post(this.baseUrl + "users/photo", formData);
  }
}
