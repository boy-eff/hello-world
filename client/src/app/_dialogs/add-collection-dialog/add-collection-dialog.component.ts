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
  isDataAvailable: boolean = false;
  onClose: BehaviorSubject<WordCollection>;
  result: WordCollection;
  themes: WordCollectionTheme[] = [];
  constructor(private fb: FormBuilder, private collectionsService: WordCollectionsService,
     public modalRef: BsModalRef, private validatorsService: ValidatorsService) { }

    ngOnInit() {
      this.collectionsService.getWordCollectionThemes().subscribe(
        result => {
          this.themes = result;
          console.log(this.themes);
          this.initializeForm();
          this.addThemeValidatorToForm();
          this.isDataAvailable = true;
      }
      );
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
    this.result = this.addForm.value;
    this.result.themeId = this.themes.find(obj => obj.name === this.result.theme).id;
    this.onClose.next(this.result);
    this.modalRef.hide(); 
  }

}
