import { Injectable } from '@angular/core';
import { AbstractControl, ValidatorFn } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidatorsService {

  constructor() { }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value ? null : 
      {isMatching: true}
    }
  }
}
