import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { EditWordComponent } from 'src/app/_dialogs/edit-word/edit-word.component';
import { Word } from 'src/app/_models/word';
import { WordCollection } from 'src/app/_models/word-collection';
import { WordCollectionsService } from 'src/app/_services/word-collections.service';

@Component({
  selector: 'app-collection-edit',
  templateUrl: './collection-edit.component.html',
  styleUrls: ['./collection-edit.component.css']
})
export class CollectionEditComponent implements OnInit {
  wordCollection: WordCollection;
  words : Word[] = [];
  wordForm : FormGroup;
  @ViewChild('value') formValue : ElementRef; 
  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  constructor(private fb: FormBuilder, private dialog: MatDialog,
     private collectionsService: WordCollectionsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.route.snapshot.params["id"];
    this.collectionsService.getWordCollection(id).subscribe(
      result => this.wordCollection = result
    )
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
