import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(private toastr: ToastrService, private router: Router) { }

  public handleError(err: HttpErrorResponse) {
    switch(err.status) {
      default:
        this.toastr.error("Something went wrong");
    }
  }
}
