import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { WordCollection } from '../_models/word-collection';

@Injectable({
  providedIn: 'root'
})
export class WordCollectionsService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  addWordCollection(wordCollection: WordCollection)
  {
    return this.http.post(this.baseUrl + "collections", wordCollection)
  }
}
