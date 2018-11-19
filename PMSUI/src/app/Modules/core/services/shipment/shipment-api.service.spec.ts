import { TestBed } from '@angular/core/testing';

import { ShipmentApiService } from '../../core/services/shipment/shipment-api.service';

describe('ShipmentApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ShipmentApiService = TestBed.get(ShipmentApiService);
    expect(service).toBeTruthy();
  });
});
