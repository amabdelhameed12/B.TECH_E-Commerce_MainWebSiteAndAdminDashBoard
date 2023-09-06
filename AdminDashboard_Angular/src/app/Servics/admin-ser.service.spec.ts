import { TestBed } from '@angular/core/testing';

import { AdminSerService } from './admin-ser.service';

describe('AdminSerService', () => {
  let service: AdminSerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminSerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
