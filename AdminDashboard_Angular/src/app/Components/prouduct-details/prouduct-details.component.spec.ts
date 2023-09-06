import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProuductDetailsComponent } from './prouduct-details.component';

describe('ProuductDetailsComponent', () => {
  let component: ProuductDetailsComponent;
  let fixture: ComponentFixture<ProuductDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProuductDetailsComponent]
    });
    fixture = TestBed.createComponent(ProuductDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
