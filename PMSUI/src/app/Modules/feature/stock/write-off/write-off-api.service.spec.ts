import { TestBed } from '@angular/core/testing';

import { WriteOffApiService } from './write-off-api.service';

describe('WriteOffApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WriteOffApiService = TestBed.get(WriteOffApiService);
    expect(service).toBeTruthy();
  });
});
