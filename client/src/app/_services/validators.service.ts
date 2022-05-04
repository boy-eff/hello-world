import { Injectable } from '@angular/core';
import { AbstractControl, ValidatorFn } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';

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

  included(arr: BehaviorSubject<string[]>): ValidatorFn {
    return (control: AbstractControl) => {
      let themes: string[];
      arr.subscribe(value => {
        themes = value
      })
      return themes.includes(control?.value) ? null : {value: control.value};
    }
  }
}
