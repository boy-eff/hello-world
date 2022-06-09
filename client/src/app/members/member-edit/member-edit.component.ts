import { Component, OnInit } from '@angular/core';
import { faPlusSquare } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';
import { UserInfo } from 'src/app/_models/user-info';
import { UserAccessToken } from 'src/app/_models/user-access-token';
import { AccountService } from 'src/app/_services/account.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  user: UserAccessToken;
  member$: Observable<UserInfo>;
  faPlusSquare = faPlusSquare;
  constructor(private accountService: AccountService, private userService: UserService) { 
    accountService.currentUser$.subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.member$ = this.userService.getUserByUsername(this.user.userName);
    this.member$.subscribe(m => console.log(m));
  }

  handleFileInput(files: FileList) {
    let photo = files.item(0);
    this.userService.uploadPhoto(photo).subscribe();
  }

}
