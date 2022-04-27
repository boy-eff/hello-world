import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  collectionName: string;
  collectionOwnerName: string;
  reviewStatus: string;

  currentChosenReview: any;
  constructor(private toast: ToastrService) { }

  ngOnInit(): void {
  }
}
