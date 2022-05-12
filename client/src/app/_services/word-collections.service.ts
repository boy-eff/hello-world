import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, shareReplay } from 'rxjs';
import { environment } from 'src/environments/environment';
import { WordCollection } from '../_models/word-collection';
import { WordCollectionTheme } from '../_models/word-collection-theme';

@Injectable({
  providedIn: 'root'
})
export class WordCollectionsService {
  baseUrl = environment.apiUrl;
  cachedThemes: Observable<WordCollectionTheme[]> = null;
  constructor(private http: HttpClient) { }

  addWordCollection(wordCollection: WordCollection)
  {
    return this.http.post(this.baseUrl + "collections", wordCollection)
  }

  getWordCollections()
  {
    return this.http.get<WordCollection[]>(this.baseUrl + "collections");
  }

  getWordCollectionThemes()
  {
    if (!this.cachedThemes)
    {
      this.cachedThemes = this.http.get<WordCollectionTheme[]>(this.baseUrl + "collections/themes").pipe(
        shareReplay(1)
      );
      console.log("from API");
    }
    return this.cachedThemes;
  }
}
