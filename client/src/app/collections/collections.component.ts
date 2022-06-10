import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AddCollectionDialogComponent } from '../_dialogs/add-collection-dialog/add-collection-dialog.component';
import { WordCollectionCreate } from '../_models/word-collection-create';
import { UserAccessToken } from '../_models/user-access-token';
import { WordCollection } from '../_models/word-collection';
import { AccountService } from '../_services/account.service';
import { WordCollectionsService } from '../_services/word-collections.service';

@Component({
  selector: 'app-collections',
  templateUrl: './collections.component.html',
  styleUrls: ['./collections.component.css']
})
export class CollectionsComponent implements OnInit {
  wordCollections: WordCollection[] = [];
  modalRef?: BsModalRef;
  modalResult: WordCollection;
  user: UserAccessToken
  constructor(private modalService: BsModalService, private accountService: AccountService,
    private wordCollectionsService: WordCollectionsService,) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe(currentUser => this.user = currentUser);
    this.updateCollections();
  }

  openModal() {
    this.modalRef = this.modalService.show(AddCollectionDialogComponent);
    this.modalRef.content.onClose.subscribe((result: WordCollectionCreate) => {
      if (result !== null)
      {
        this.wordCollectionsService.addWordCollection(result).subscribe( result => this.updateCollections());
      }
    });
  }

  updateCollections() {
    this.wordCollectionsService.getUserCollections(this.user.id).subscribe(
      result => this.wordCollections = result
    )
  }
}
