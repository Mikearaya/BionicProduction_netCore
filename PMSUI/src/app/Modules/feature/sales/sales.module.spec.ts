import { SalesModule } from './sales.module';

describe('SalesModule', () => {
  let salesModule: SalesModule;

  beforeEach(() => {
    salesModule = new SalesModule();
  });

  it('should create an instance', () => {
    expect(salesModule).toBeTruthy();
  });
});
