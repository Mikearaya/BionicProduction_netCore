import { TestBed, inject } from '@angular/core/testing';

import { CoreApiService } from './core-api.service';

describe('CoreApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CoreApiService]
    });
  });

  it('should be created', inject([CoreApiService], (service: CoreApiService) => {
    expect(service).toBeTruthy();
  }));

});
