import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPanelReviewsComponent } from './admin-panel-reviews.component';

describe('AdminPanelReviewsComponent', () => {
  let component: AdminPanelReviewsComponent;
  let fixture: ComponentFixture<AdminPanelReviewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminPanelReviewsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminPanelReviewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
