import { TestBed } from '@angular/core/testing';

import { StorageLocationApiService } from './storage-location-api.service';

describe('StorageLocationApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StorageLocationApiService = TestBed.get(StorageLocationApiService);
    expect(service).toBeTruthy();
  });
});
