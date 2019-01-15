import { TestBed, inject } from '@angular/core/testing';

import { BookingApiService } from './booking-api.service';

describe('BookingApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookingApiService]
    });
  });

  it('should be created', inject([BookingApiService], (service: BookingApiService) => {
    expect(service).toBeTruthy();
  }));
});
