import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Word } from '../_models/word';
import { WordEdit } from '../_models/word-edit';

@Injectable({
  providedIn: 'root'
})
export class WordService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  updateCollectionWords(collectionId: number, words: WordEdit[])
  {
    return this.http.post(this.baseUrl + "collections/" + collectionId + "/words", words);
  }

  getCollectionWords(collectionId: number)
  {
    return this.http.get<Word[]>(this.baseUrl + "collections/" + collectionId + "/words")
  }
}
