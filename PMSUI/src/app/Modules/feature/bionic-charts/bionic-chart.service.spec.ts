import { TestBed } from '@angular/core/testing';

import { BionicChartService } from './bionic-chart.service';

describe('BionicChartService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BionicChartService = TestBed.get(BionicChartService);
    expect(service).toBeTruthy();
  });
});
