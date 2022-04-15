import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm : FormGroup;
  constructor(private accountService: AccountService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      "userName": ['', Validators.required],
      "password": ['', Validators.required],
    });
    }

  login()
  {
    this.accountService.login(this.loginForm.value).subscribe();
  }
}
