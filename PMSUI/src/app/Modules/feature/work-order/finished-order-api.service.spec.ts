import { TestBed, inject } from '@angular/core/testing';

import { FinishedOrderApiService } from './finished-order-api.service';

describe('FinishedOrderApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FinishedOrderApiService]
    });
  });

  it('should be created', inject([FinishedOrderApiService], (service: FinishedOrderApiService) => {
    expect(service).toBeTruthy();
  }));
});
