import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Word } from 'src/app/_models/word';

@Component({
  selector: 'app-edit-word',
  templateUrl: './edit-word.component.html',
  styleUrls: ['./edit-word.component.css']
})
export class EditWordComponent implements OnInit {
  editForm: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<EditWordComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Word, private fb: FormBuilder
  ) {
  }
  ngOnInit(): void {
    this.editForm = this.fb.group(
      {
        "value": [this.data.value, Validators.required],
        "translation": [this.data.translation, Validators.required],
      }
    )
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  editWord()
  {
    this.data = this.editForm.value;
    this.dialogRef.close(this.data);
  }
}
