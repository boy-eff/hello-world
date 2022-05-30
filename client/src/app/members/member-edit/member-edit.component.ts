import { Component, OnInit } from '@angular/core';
import { faPlusSquare } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MemberService } from 'src/app/_services/member.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  user: User;
  member$: Observable<Member>;
  faPlusSquare = faPlusSquare;
  constructor(private accountService: AccountService, private memberService: MemberService) { 
    accountService.currentUser$.subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.member$ = this.memberService.getMemberByUsername(this.user.userName);
    this.member$.subscribe(m => console.log(m));
  }

  handleFileInput(files: FileList) {
    let photo = files.item(0);
    this.memberService.uploadPhoto(photo).subscribe();
  }

}
