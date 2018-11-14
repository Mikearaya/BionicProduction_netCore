import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentSummaryViewComponent } from './shipment-summary-view.component';

describe('ShipmentSummaryViewComponent', () => {
  let component: ShipmentSummaryViewComponent;
  let fixture: ComponentFixture<ShipmentSummaryViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShipmentSummaryViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShipmentSummaryViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
