import { TestBed } from '@angular/core/testing';

import { UnitOfMeasurmentApiService } from './unit-of-measurment-api.service';

describe('UnitOfMeasurmentApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UnitOfMeasurmentApiService = TestBed.get(UnitOfMeasurmentApiService);
    expect(service).toBeTruthy();
  });
});
