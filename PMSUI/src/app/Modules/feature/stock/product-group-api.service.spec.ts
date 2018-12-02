import { TestBed } from '@angular/core/testing';

import { ProductGroupApiService } from './product-group-api.service';

describe('ProductGroupApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductGroupApiService = TestBed.get(ProductGroupApiService);
    expect(service).toBeTruthy();
  });
});
