import { TestBed, inject } from '@angular/core/testing';

import { SaleInvoiceApiService } from './sale-invoice-api.service';

describe('SaleInvoiceApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SaleInvoiceApiService]
    });
  });

  it('should be created', inject([SaleInvoiceApiService], (service: SaleInvoiceApiService) => {
    expect(service).toBeTruthy();
  }));
});
