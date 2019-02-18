import { TestBed } from '@angular/core/testing';

import { PurchaseOrderApiService } from '../purchase-order-api.service';

describe('PurchaseOrderApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PurchaseOrderApiService = TestBed.get(PurchaseOrderApiService);
    expect(service).toBeTruthy();
  });
});
