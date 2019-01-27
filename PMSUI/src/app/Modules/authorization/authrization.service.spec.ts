import { TestBed } from '@angular/core/testing';

import { AuthrizationService } from './authrization.service';

describe('AuthrizationService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AuthrizationService = TestBed.get(AuthrizationService);
    expect(service).toBeTruthy();
  });
});
