import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import { EditWordComponent } from 'src/app/_dialogs/edit-word/edit-word.component';
import { Word } from 'src/app/_models/word';
import { WordCollectionsService } from 'src/app/_services/word-collections.service';

@Component({
  selector: 'app-collection-create',
  templateUrl: './collection-create.component.html',
  styleUrls: ['./collection-create.component.css']
})
export class CollectionCreateComponent implements OnInit {
  words : Word[] = [];
  wordForm : FormGroup;
  collectionName : string = "";
  @ViewChild('value') formValue : ElementRef; 
  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  constructor(private fb: FormBuilder, private dialog: MatDialog,
     private collectionsService: WordCollectionsService) { }

  ngOnInit(): void {
    this.wordForm = this.fb.group(
      {
        "value": ['', Validators.required],
        "translation": ['', Validators.required],
      }
    )
  }

  addWord()
  {
    this.words.push(this.wordForm.value);
    this.formValue.nativeElement.focus();
    this.wordForm.reset();
    this.formDirective.resetForm();
  }

  addCollection()
  {
    let collection = {name: this.collectionName, words: this.words};
    //this.collectionsService.addWordCollection(collection);
  }

  removeWord(word: Word)
  {
    const index = this.words.indexOf(word, 0);
    if (index > -1) {
    this.words.splice(index, 1);
    }
  }

  editWord(word: Word)
  {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.height = "300px";
    dialogConfig.width = "300px";
    dialogConfig.data = word;

    let dialogRef = this.dialog.open(EditWordComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(
      data => {
        word.value = data.value;
        word.translation = data.translation;
      }
    )
  }

}
