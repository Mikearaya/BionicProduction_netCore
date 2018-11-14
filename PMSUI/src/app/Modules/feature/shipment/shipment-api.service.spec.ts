import { TestBed } from '@angular/core/testing';

import { ShipmentApiService } from './shipment-api.service';

describe('ShipmentApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ShipmentApiService = TestBed.get(ShipmentApiService);
    expect(service).toBeTruthy();
  });
});
