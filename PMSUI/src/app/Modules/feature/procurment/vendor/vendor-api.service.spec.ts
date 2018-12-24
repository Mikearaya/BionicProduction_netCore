import { TestBed } from '@angular/core/testing';

import { VendorApiService } from './vendor-api.service';

describe('VendorApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VendorApiService = TestBed.get(VendorApiService);
    expect(service).toBeTruthy();
  });
});
