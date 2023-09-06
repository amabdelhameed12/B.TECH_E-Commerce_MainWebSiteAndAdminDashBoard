import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewProudutComponent } from './add-new-proudut.component';

describe('AddNewProudutComponent', () => {
  let component: AddNewProudutComponent;
  let fixture: ComponentFixture<AddNewProudutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddNewProudutComponent]
    });
    fixture = TestBed.createComponent(AddNewProudutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
