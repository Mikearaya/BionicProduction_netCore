import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseOrderViewComponent } from './purchase-order-view.component';

describe('PurchaseOrderViewComponent', () => {
  let component: PurchaseOrderViewComponent;
  let fixture: ComponentFixture<PurchaseOrderViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseOrderViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseOrderViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
