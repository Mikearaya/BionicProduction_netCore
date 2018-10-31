/*
 * @CreateTime: Sep 12, 2018 12:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:49 AM
 * @Description: Modify Here, Please
 */
import { WorkOrderModule } from './work-order.module';

describe('WorkOrderModule', () => {
  let workOrderModule: WorkOrderModule;

  beforeEach(() => {
    workOrderModule = new WorkOrderModule();
  });

  it('should create an instance', () => {
    expect(workOrderModule).toBeTruthy();
  });
});
