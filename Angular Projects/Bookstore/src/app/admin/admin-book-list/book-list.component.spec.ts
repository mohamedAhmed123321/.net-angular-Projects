import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AminBookListComponent } from './admin-book-list.component';

describe('AminBookListComponent', () => {
  let component: AminBookListComponent;
  let fixture: ComponentFixture<AminBookListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AminBookListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AminBookListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
