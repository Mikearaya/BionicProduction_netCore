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
