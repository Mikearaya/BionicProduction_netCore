import { TestBed, inject } from '@angular/core/testing';

import { ProductGetterService } from './product-getter.service';

describe('ProductGetterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductGetterService]
    });
  });

  it('should be created', inject([ProductGetterService], (service: ProductGetterService) => {
    expect(service).toBeTruthy();
  }));
});
