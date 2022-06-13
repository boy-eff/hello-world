import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Word } from 'src/app/_models/word';
import { WordService } from 'src/app/_services/word.service';

@Component({
  selector: 'app-collection-choose-translation',
  templateUrl: './collection-choose-translation.component.html',
  styleUrls: ['./collection-choose-translation.component.css']
})
export class CollectionChooseTranslationComponent implements OnInit {
  currentWord: number = 0;
  collectionId: number;
  totalWords: number = 10;
  words: Word[] = [];
  constructor(private wordService: WordService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.collectionId = this.route.snapshot.params["id"];
    this.wordService.getCollectionWords(this.collectionId).subscribe(result => 
    {
      this.words = result;
      
    });
  }

}
