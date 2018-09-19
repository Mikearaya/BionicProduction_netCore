import { TestBed, inject } from '@angular/core/testing';

import { FinishedProductsApiService } from './finished-products-api.service';

describe('FinishedProductsApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FinishedProductsApiService]
    });
  });

  it('should be created', inject([FinishedProductsApiService], (service: FinishedProductsApiService) => {
    expect(service).toBeTruthy();
  }));
});
