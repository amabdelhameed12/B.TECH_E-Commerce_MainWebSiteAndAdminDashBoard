import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProudectComponent } from './Proudect.component';

describe('AddProudectComponent', () => {
  let component: AddProudectComponent;
  let fixture: ComponentFixture<AddProudectComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddProudectComponent]
    });
    fixture = TestBed.createComponent(AddProudectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
