import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Word } from '../_models/word';

@Injectable({
  providedIn: 'root'
})
export class WordService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  updateCollectionWords(colllectionId: number, words: Word[])
  {
    return this.http.post<Word[]>(this.baseUrl + "collections/" + colllectionId + "/words", words);
  }
}
