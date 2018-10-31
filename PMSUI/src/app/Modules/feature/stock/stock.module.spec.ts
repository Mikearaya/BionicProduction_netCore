import { StockModule } from './stock.module';


describe('StockModule', () => {
  let StockModules: StockModule;

  beforeEach(() => {
    StockModules = new StockModule();
  });

  it('should create an instance', () => {
    expect(StockModules).toBeTruthy();
  });
});
