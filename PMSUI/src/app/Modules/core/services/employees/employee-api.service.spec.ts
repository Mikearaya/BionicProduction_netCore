import { TestBed, inject } from '@angular/core/testing';

import { EmployeeApiService } from './employee-api.service';

describe('EmployeeApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmployeeApiService]
    });
  });

  it('should be created', inject([EmployeeApiService], (service: EmployeeApiService) => {
    expect(service).toBeTruthy();
  }));
});
