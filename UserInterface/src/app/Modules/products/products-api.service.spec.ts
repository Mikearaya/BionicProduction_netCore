import { TestBed } from '@angular/core/testing';

import { ProductsAPIService } from './products-api.service';

describe('ProductsAPIService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductsAPIService = TestBed.get(ProductsAPIService);
    expect(service).toBeTruthy();
  });
});
