import { Injectable } from '@angular/core';
import { AbstractControl, ValidatorFn } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { WordCollectionTheme } from '../_models/word-collection-theme';

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

  included(arr: string[]): ValidatorFn {
    return (control: AbstractControl) => {
      return arr.includes(control?.value) ? null : {value: control.value};
    }
  }
}
