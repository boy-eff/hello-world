import { Component, OnInit } from '@angular/core';
import { UserAccessToken } from './_models/user-access-token';
import { AccountService } from './_services/account.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  constructor(private accountService : AccountService)
  {

  }
  ngOnInit(): void {
    this.setCurrentUser();
  }
  
  setCurrentUser() {
    const user: UserAccessToken = JSON.parse(localStorage.getItem("user")!);
    if (user) {
      this.accountService.setCurrentUser(user);
    }
  }
}


