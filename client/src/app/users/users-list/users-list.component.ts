import { Component, OnInit } from '@angular/core';
import { UserInfo } from 'src/app/_models/user-info';
import { MemberService } from 'src/app/_services/member.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {
  users: UserInfo[];
  constructor(private memberService: MemberService) { }

  ngOnInit(): void {
    this.memberService.getUsers().subscribe(result => {
      this.users = result;
      console.log(result);
    });
  }

}
