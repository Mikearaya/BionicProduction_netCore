import { TestBed } from '@angular/core/testing';

import { RoutingApiService } from './routing-api.service';

describe('RoutingApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RoutingApiService = TestBed.get(RoutingApiService);
    expect(service).toBeTruthy();
  });
});
