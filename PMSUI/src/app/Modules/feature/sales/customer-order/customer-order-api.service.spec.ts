import { TestBed, inject } from '@angular/core/testing';

import { CustomerOrderApiService } from './customer-order-api.service';


describe('CustomerOrderApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CustomerOrderApiService]
    });
  });

  it('should be created', inject([CustomerOrderApiService], (service: CustomerOrderApiService) => {
    expect(service).toBeTruthy();
  }));
});
