import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesInvoiceViewComponent } from './sales-invoice-view.component';

describe('SalesInvoiceViewComponent', () => {
  let component: SalesInvoiceViewComponent;
  let fixture: ComponentFixture<SalesInvoiceViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesInvoiceViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesInvoiceViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
