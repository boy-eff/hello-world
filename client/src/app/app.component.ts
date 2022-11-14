import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserAccessToken } from './_models/user-access-token';
import { AccountService } from './_services/account.service';
import { LoadingService } from './_services/loading.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  constructor(private accountService : AccountService, 
    private loadingService: LoadingService, private spinner: NgxSpinnerService)
  {

  }
  ngOnInit(): void {
    this.setCurrentUser();
    this.loadingService.loading$.subscribe((value: boolean) => {
      if (value)
      {
        this.spinner.show();
      }
      else
      {
        this.spinner.hide();
      }
    })
  }
  
  setCurrentUser() {
    const user: UserAccessToken = JSON.parse(localStorage.getItem("user")!);
    if (user) {
      this.accountService.setCurrentUser(user);
    }
  }
}


