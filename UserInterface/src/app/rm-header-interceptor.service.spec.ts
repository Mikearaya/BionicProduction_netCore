import { TestBed, inject } from '@angular/core/testing';

import { RmHeaderInterceptorService } from './rm-header-interceptor.service';

describe('RmHeaderInterceptorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RmHeaderInterceptorService]
    });
  });

  it('should be created', inject([RmHeaderInterceptorService], (service: RmHeaderInterceptorService) => {
    expect(service).toBeTruthy();
  }));
});
