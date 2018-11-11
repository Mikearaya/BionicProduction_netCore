import { TestBed } from '@angular/core/testing';

import { CustomerOrderGetterApiService } from './customer-order-getter-api.service';

describe('CustomerOrderGetterApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CustomerOrderGetterApiService = TestBed.get(CustomerOrderGetterApiService);
    expect(service).toBeTruthy();
  });
});
