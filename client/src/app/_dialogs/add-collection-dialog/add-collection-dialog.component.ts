import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { waitForAsync } from '@angular/core/testing';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { BehaviorSubject } from 'rxjs';
import { WordCollection } from 'src/app/_models/word-collection';
import { WordCollectionTheme } from 'src/app/_models/word-collection-theme';
import { ValidatorsService } from 'src/app/_services/validators.service';
import { WordCollectionsService } from 'src/app/_services/word-collections.service';

@Component({
  selector: 'app-add-collection-dialog',
  templateUrl: './add-collection-dialog.component.html',
  styleUrls: ['./add-collection-dialog.component.css']
})
export class AddCollectionDialogComponent implements OnInit {
  addForm: FormGroup;
  onClose: BehaviorSubject<WordCollection>;
  themes: BehaviorSubject<string[]>;
  constructor(private fb: FormBuilder, private collectionsService: WordCollectionsService,
     public modalRef: BsModalRef, private validatorsService: ValidatorsService) { }

    ngOnInit(): void {
    this.themes = new BehaviorSubject([]);
      this.collectionsService.getWordCollectionThemes().subscribe(
        result => {
          this.themes.next(result.map(r => r.name))
        }
      )
    this.initializeForm();
    this.onClose = new BehaviorSubject(null);
  }

  initializeForm()
  {
    this.addForm = this.fb.group(
      {
        "name": ["", Validators.required],
        "theme": ["", [Validators.required, this.validatorsService.included(this.themes)]],
        "description": [""]
      });
  }

  addCollection(): void {

    this.onClose.next(this.addForm.value);
    this.modalRef.hide();
    
  }

}
