import { TestBed } from '@angular/core/testing';

import { StockBatchApiService } from './stock-batch-api.service';

describe('StockBatchApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StockBatchApiService = TestBed.get(StockBatchApiService);
    expect(service).toBeTruthy();
  });
});
