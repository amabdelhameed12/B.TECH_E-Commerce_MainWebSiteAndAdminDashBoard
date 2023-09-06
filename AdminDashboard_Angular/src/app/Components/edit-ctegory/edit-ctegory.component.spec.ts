import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCtegoryComponent } from './edit-ctegory.component';

describe('EditCtegoryComponent', () => {
  let component: EditCtegoryComponent;
  let fixture: ComponentFixture<EditCtegoryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditCtegoryComponent]
    });
    fixture = TestBed.createComponent(EditCtegoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
