import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm : FormGroup;
  constructor(private accountService: AccountService, private fb: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      "userName": ['', [Validators.required, Validators.minLength(4)]],
      "password": ['', [Validators.required, Validators.minLength(6)]],
    });
    }

  login()
  {
    this.accountService.login(this.loginForm.value).subscribe(() => {
      this.router.navigateByUrl("/");
    });
  }
}
