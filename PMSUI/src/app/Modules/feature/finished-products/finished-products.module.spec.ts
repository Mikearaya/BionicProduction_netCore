import { FinishedProductsModule } from './finished-products.module';

describe('FinishedProductsModule', () => {
  let finishedProductsModule: FinishedProductsModule;

  beforeEach(() => {
    finishedProductsModule = new FinishedProductsModule();
  });

  it('should create an instance', () => {
    expect(finishedProductsModule).toBeTruthy();
  });
});
