import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
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
      private validatorsService: ValidatorsService) {
    
   }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      "userName": ['', Validators.required],
      "password": ['', Validators.required],
      "confirmPassword": ['', [Validators.required, this.validatorsService.matchValues('password')]]
    });
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }

  register()
  {
    this.accountService.register(this.registerForm.value).subscribe();
  }

}
