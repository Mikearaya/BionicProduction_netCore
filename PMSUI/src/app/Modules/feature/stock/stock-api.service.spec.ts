import { TestBed, inject } from '@angular/core/testing';

import { StockApiService } from './stock-api.service';

describe('StockApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StockApiService]
    });
  });

  it('should be created', inject([StockApiService], (service: StockApiService) => {
    expect(service).toBeTruthy();
  }));
});
