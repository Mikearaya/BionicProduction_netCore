import { TestBed } from '@angular/core/testing';

import { PurchaseTermApiService } from './purchase-term-api.service';

describe('PurchaseTermApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PurchaseTermApiService = TestBed.get(PurchaseTermApiService);
    expect(service).toBeTruthy();
  });
});
