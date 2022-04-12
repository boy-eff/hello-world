import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(private accountService: AccountService, private fb: FormBuilder) {
    
   }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.fb.group({
      "userName": new FormControl(null, Validators.required),
      "Password": new FormControl(null, Validators.required),
      "confirmPassword": new FormControl(null, [Validators.required, this.matchValues('Password')])
    });
    this.registerForm.controls["Password"].valueChanges.subscribe(() => {
      this.registerForm.controls["confirmPassword"].updateValueAndValidity();
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value ? null : 
      {isMatching: true}
    }
  }

  register()
  {
    this.accountService.register(this.registerForm.value);
  }

}