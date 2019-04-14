import { TestBed } from '@angular/core/testing';

import { BomApiService } from './bom-api.service';

describe('BomApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BomApiService = TestBed.get(BomApiService);
    expect(service).toBeTruthy();
  });
});
