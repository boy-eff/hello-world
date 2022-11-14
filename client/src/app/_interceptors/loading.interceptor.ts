import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, PartialObserver, tap } from 'rxjs';
import { LoadingService } from '../_services/loading.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  private readonly observer: PartialObserver<any> = { 
    error: () => this.loadingService.stop(), 
    complete: () => this.loadingService.stop() 
  }; 

  constructor(private loadingService: LoadingService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.loadingService.start();
    return next.handle(request).pipe(
      tap(this.observer)
    );
  }
}
