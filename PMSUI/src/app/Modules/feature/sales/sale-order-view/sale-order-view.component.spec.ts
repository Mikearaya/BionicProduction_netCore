import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleOrderViewComponent } from './sale-order-view.component';

describe('SaleOrderViewComponent', () => {
  let component: SaleOrderViewComponent;
  let fixture: ComponentFixture<SaleOrderViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaleOrderViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaleOrderViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
