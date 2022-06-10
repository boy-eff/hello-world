import { Component, OnInit } from '@angular/core';
import { UserInfo } from 'src/app/_models/user-info';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {
  users: UserInfo[];
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(result => {
      this.users = result;
      console.log(result);
    });
  }

}
