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
    let message;
    switch(err.status) {
      case 400:
        message = "Bad request";
        break;
      case 401:
        message = err.error ? err.error : "Unauthorized";
        break;
      case 409:
        message = err.error;
        break;
      case 500:
        message = "Internal server error";
        break;
      default:
        message = "Something went wrong";
    }
    this.toastr.error(message);
  }
}
