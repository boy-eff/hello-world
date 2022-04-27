import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AddCollectionDialogComponent } from '../_dialogs/add-collection-dialog/add-collection-dialog.component';
import { WordCollection } from '../_models/word-collection';

@Component({
  selector: 'app-collections',
  templateUrl: './collections.component.html',
  styleUrls: ['./collections.component.css']
})
export class CollectionsComponent implements OnInit {
  wordCollections: WordCollection[] = [];
  modalRef?: BsModalRef;
  modalResult: WordCollection;
  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  openModal() {
    this.modalRef = this.modalService.show(AddCollectionDialogComponent);
    this.modalRef.content.onClose.subscribe((result: WordCollection) => {
      if (result !== null)
      {
        this.wordCollections.push(result)
      }
    });
  }
}
