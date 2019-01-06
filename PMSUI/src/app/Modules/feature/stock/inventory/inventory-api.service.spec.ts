import { TestBed } from '@angular/core/testing';

import { InventoryApiService } from './inventory-api.service';

describe('InventoryApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: InventoryApiService = TestBed.get(InventoryApiService);
    expect(service).toBeTruthy();
  });
});
