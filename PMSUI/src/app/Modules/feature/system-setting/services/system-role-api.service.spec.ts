import { TestBed } from '@angular/core/testing';

import { SystemRoleApiService } from './system-role-api.service';

describe('SystemRoleApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SystemRoleApiService = TestBed.get(SystemRoleApiService);
    expect(service).toBeTruthy();
  });
});
