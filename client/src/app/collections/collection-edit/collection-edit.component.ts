import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { EditWordComponent } from 'src/app/_dialogs/edit-word/edit-word.component';
import { Word } from 'src/app/_models/word';
import { WordCollection } from 'src/app/_models/word-collection';
import { WordEdit } from 'src/app/_models/word-edit';
import { WordCollectionsService } from 'src/app/_services/word-collections.service';
import { WordService } from 'src/app/_services/word.service';

@Component({
  selector: 'app-collection-edit',
  templateUrl: './collection-edit.component.html',
  styleUrls: ['./collection-edit.component.css']
})
export class CollectionEditComponent implements OnInit {
  wordCollection: WordCollection;
  words : WordEdit[] = [];
  wordForm : FormGroup;
  id : number;
  @ViewChild('value') formValue : ElementRef; 
  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  constructor(private fb: FormBuilder, private dialog: MatDialog, private wordService: WordService,
     private collectionsService: WordCollectionsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params["id"];
    this.collectionsService.getWordCollection(this.id).subscribe(
      result => {
        this.wordCollection = result;
        this.initializeWords();
      }
    );
    this.initializeForm();
  }
  
  initializeForm() {
    this.wordForm = this.fb.group(
      {
        "value": ['', Validators.required],
        "translation": ['', Validators.required],
      }
    )
  }

  initializeWords() {
     this.wordCollection.words.forEach(el => {
      this.words.push({
        id: el.id,
        value: el.value,
        translation: el.translation,
        wordCollectionId: el.wordCollectionId,
        isModified: false,
        isDeleted: false
      })
     })
  }

  addWord()
  {
    this.words.push({
      id: null,
      value: this.wordForm.value.value,
      translation: this.wordForm.value.translation,
      wordCollectionId: this.id,
      isModified: true,
      isDeleted: false
    });
    this.formValue.nativeElement.focus();
    this.wordForm.reset();
    this.formDirective.resetForm();
  }

  removeWord(word: WordEdit)
  {
    word.isDeleted = true;
  }

  editWord(word: WordEdit)
  {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.height = "300px";
    dialogConfig.width = "300px";
    dialogConfig.data = word;

    let dialogRef = this.dialog.open(EditWordComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(
      data => {
        if (data)
        {
          word.value = data.value;
          word.translation = data.translation;
          word.isModified = true;
        }
      }
    )
  }

  saveChanges() {
    this.wordService.updateCollectionWords(this.id, this.words.filter
      (word =>  word.isModified || word.isDeleted)
    ).subscribe();
  }

}
