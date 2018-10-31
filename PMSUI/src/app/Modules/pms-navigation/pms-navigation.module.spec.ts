import { PmsNavigationModule } from './pms-navigation.module';

describe('PmsNavigationModule', () => {
  let pmsNavigationModule: PmsNavigationModule;

  beforeEach(() => {
    pmsNavigationModule = new PmsNavigationModule();
  });

  it('should create an instance', () => {
    expect(pmsNavigationModule).toBeTruthy();
  });
});
