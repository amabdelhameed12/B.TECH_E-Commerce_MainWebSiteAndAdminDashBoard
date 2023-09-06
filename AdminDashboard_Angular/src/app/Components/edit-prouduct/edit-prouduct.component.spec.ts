import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditProuductComponent } from './edit-prouduct.component';

describe('EditProuductComponent', () => {
  let component: EditProuductComponent;
  let fixture: ComponentFixture<EditProuductComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditProuductComponent]
    });
    fixture = TestBed.createComponent(EditProuductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
