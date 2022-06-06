import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, shareReplay } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateWordCollection } from '../_models/create-word-collection';
import { Word } from '../_models/word';
import { WordCollection } from '../_models/word-collection';
import { WordCollectionTheme } from '../_models/word-collection-theme';

@Injectable({
  providedIn: 'root'
})
export class WordCollectionsService {
  baseUrl = environment.apiUrl;
  cachedThemes: Observable<WordCollectionTheme[]> = null;
  constructor(private http: HttpClient) { }

  addWordCollection(wordCollection: CreateWordCollection)
  {
    return this.http.post(this.baseUrl + "collections", wordCollection)
  }

  getUserCollections(userId: number)
  {
    return this.http.get<WordCollection[]>(this.baseUrl + "collections/users/" + userId);
  }

  getWordCollection(collectionId: number)
  {
    return this.http.get<WordCollection>(this.baseUrl + "collections/" + collectionId);
  }

  getWordCollectionThemes()
  {
    if (!this.cachedThemes)
    {
      this.cachedThemes = this.http.get<WordCollectionTheme[]>(this.baseUrl + "collections/themes").pipe(
        shareReplay(1)
      );
    }
    return this.cachedThemes;
  }

  addWordToCollection(word: Word)
  {
    if (word.value && word.translation && word.wordCollectionId)
    {
      return this.http.post(this.baseUrl + "collection/words", word);
    }
    return null;
  }
}
