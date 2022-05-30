import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getMemberByUsername(username: string): Observable<Member> {
    return this.http.get<Member>(this.baseUrl + "users/" + username);
  }

  uploadPhoto(photo: File)
  {
    let formData = new FormData();
    formData.append("file", photo);
    return this.http.post(this.baseUrl + "users/photo", formData);
  }
}
