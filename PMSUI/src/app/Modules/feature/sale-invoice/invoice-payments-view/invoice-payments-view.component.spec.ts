import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InvoicePaymentsViewComponent } from './invoice-payments-view.component';

describe('InvoicePaymentsViewComponent', () => {
  let component: InvoicePaymentsViewComponent;
  let fixture: ComponentFixture<InvoicePaymentsViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InvoicePaymentsViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InvoicePaymentsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
