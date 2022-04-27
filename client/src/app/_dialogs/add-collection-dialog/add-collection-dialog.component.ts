import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { BehaviorSubject } from 'rxjs';
import { WordCollection } from 'src/app/_models/word-collection';

@Component({
  selector: 'app-add-collection-dialog',
  templateUrl: './add-collection-dialog.component.html',
  styleUrls: ['./add-collection-dialog.component.css']
})
export class AddCollectionDialogComponent implements OnInit {
  addForm: FormGroup;
  onClose: BehaviorSubject<WordCollection>;
  constructor(private fb: FormBuilder, public modalRef: BsModalRef) { }

  ngOnInit(): void {
    this.addForm = this.fb.group(
      {
        "name": ["", Validators.required],
        "theme": ["", Validators.required],
        "description": [""]
      });
    this.onClose = new BehaviorSubject(null);
  }

  addCollection(): void {
    this.onClose.next(this.addForm.value);
    this.modalRef.hide();
  }

}
