import { SaleInvoiceModule } from './sale-invoice.module';

describe('SaleInvoiceModule', () => {
  let saleInvoiceModule: SaleInvoiceModule;

  beforeEach(() => {
    saleInvoiceModule = new SaleInvoiceModule();
  });

  it('should create an instance', () => {
    expect(saleInvoiceModule).toBeTruthy();
  });
});
