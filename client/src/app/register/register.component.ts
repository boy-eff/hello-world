import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ValidatorsService } from '../_services/validators.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(private accountService: AccountService, private fb: FormBuilder,
      private validatorsService: ValidatorsService, private router: Router) {
    
   }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      "userName": ['', Validators.minLength(4) ],
      "password": ['', Validators.minLength(6)],
      "confirmPassword": ['', [Validators.required, this.validatorsService.matchValues('password')]]
    });
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }

  register()
  {
    this.accountService.register(this.registerForm.value).subscribe(() => {
      this.router.navigateByUrl("/");
    });
  }
}
