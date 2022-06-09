import { Component, Input, OnInit } from '@angular/core';
import { UserInfo } from 'src/app/_models/user-info';

@Component({
  selector: 'app-users-card',
  templateUrl: './users-card.component.html',
  styleUrls: ['./users-card.component.css']
})
export class UsersCardComponent implements OnInit {
  @Input() user: UserInfo;
  constructor() { }

  ngOnInit(): void {
  }

}
