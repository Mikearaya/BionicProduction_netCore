/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:49 AM
 * @Description: Modify Here, Please
 */
import { TestBed } from '@angular/core/testing';

import { WorkOrderAPIService } from './work-order-api.service';

describe('WorkOrderAPIService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkOrderAPIService = TestBed.get(WorkOrderAPIService);
    expect(service).toBeTruthy();
  });
});
