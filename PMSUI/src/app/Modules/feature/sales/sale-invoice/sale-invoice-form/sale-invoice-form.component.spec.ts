import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleInvoiceFormComponent } from './sale-invoice-form.component';

describe('SaleInvoiceFormComponent', () => {
  let component: SaleInvoiceFormComponent;
  let fixture: ComponentFixture<SaleInvoiceFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaleInvoiceFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaleInvoiceFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
