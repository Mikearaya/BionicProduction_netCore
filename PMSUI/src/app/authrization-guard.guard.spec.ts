import { TestBed, async, inject } from '@angular/core/testing';

import { AuthrizationGuardGuard } from './authrization-guard.guard';

describe('AuthrizationGuardGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuthrizationGuardGuard]
    });
  });

  it('should ...', inject([AuthrizationGuardGuard], (guard: AuthrizationGuardGuard) => {
    expect(guard).toBeTruthy();
  }));
});
