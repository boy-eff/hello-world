import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserAccessToken } from '../_models/user-access-token';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<UserAccessToken>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  register(model: any)
  {
    return this.http.post(this.baseUrl + "account/register", model);
  }

  login(model: any)
  {
    return this.http.post<UserAccessToken>(this.baseUrl + "account/login", model).pipe(
      map((response: UserAccessToken) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      })
    )
  }

  setCurrentUser(user: UserAccessToken) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null); 
  }
}
