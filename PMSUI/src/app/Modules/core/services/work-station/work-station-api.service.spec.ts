import { TestBed } from '@angular/core/testing';

import { WorkStationApiService } from './work-station-api.service';

describe('WorkStationApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkStationApiService = TestBed.get(WorkStationApiService);
    expect(service).toBeTruthy();
  });
});
