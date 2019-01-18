import { TestBed, inject } from '@angular/core/testing';

import { SaleOrderApiService } from './sale-order-api.service';

describe('SaleOrderApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SaleOrderApiService]
    });
  });

  it('should be created', inject([SaleOrderApiService], (service: SaleOrderApiService) => {
    expect(service).toBeTruthy();
  }));
});
