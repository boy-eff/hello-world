import { Injectable } from '@angular/core';
import { BehaviorSubject, delay, distinctUntilChanged, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  private loading = 0;

  private readonly _loading$: Subject<boolean> = new BehaviorSubject<boolean>(false);
  
  readonly loading$: Observable<boolean> = this._loading$.pipe(
    distinctUntilChanged(),
    delay(0)
  );

  constructor() { }

  start() {
    this.loading++;
    this.emit();
  }

  stop() { 
    if (this.loading > 0) { 
      this.loading--; 
      this.emit(); 
    } 
  } 

  private emit() { 
    this._loading$.next(this.isLoading()); 
  } 
 
  private isLoading(): boolean { 
    return this.loading > 0; 
  } 
}
