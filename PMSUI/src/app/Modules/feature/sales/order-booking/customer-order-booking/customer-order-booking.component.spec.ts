import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerOrderBookingComponent } from './customer-order-booking.component';

describe('CustomerOrderBookingComponent', () => {
  let component: CustomerOrderBookingComponent;
  let fixture: ComponentFixture<CustomerOrderBookingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerOrderBookingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerOrderBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
