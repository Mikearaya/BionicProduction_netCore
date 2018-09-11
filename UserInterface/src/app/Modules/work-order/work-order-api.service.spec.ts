import { TestBed } from '@angular/core/testing';

import { WorkOrderAPIService } from './work-order-api.service';

describe('WorkOrderAPIService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkOrderAPIService = TestBed.get(WorkOrderAPIService);
    expect(service).toBeTruthy();
  });
});
