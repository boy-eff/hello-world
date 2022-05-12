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
  themes: WordCollectionTheme[] = [];
  constructor(private fb: FormBuilder, private collectionsService: WordCollectionsService,
     public modalRef: BsModalRef, private validatorsService: ValidatorsService) { }

    ngOnInit() {
      this.collectionsService.getWordCollectionThemes().subscribe(
        result => {
          this.themes = result;
          this.addThemeValidatorToForm();
      }
      );
      this.initializeForm();
      
      this.onClose = new BehaviorSubject(null);
  }

  initializeForm()
  {
    this.addForm = this.fb.group(
      {
        "name": ["", Validators.required],
        "theme": ["", [Validators.required]],
        "description": [""]
      });
  }

  addThemeValidatorToForm()
  {
    this.addForm.controls["theme"].addValidators(this.validatorsService
      .included(this.themes.map(r => r.name)))
  }

  addCollection(): void {
    this.onClose.next(this.addForm.value);
    this.modalRef.hide(); 
  }

}
