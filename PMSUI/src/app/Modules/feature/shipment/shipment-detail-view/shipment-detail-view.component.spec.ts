import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentDetailViewComponent } from './shipment-detail-view.component';

describe('ShipmentDetailViewComponent', () => {
  let component: ShipmentDetailViewComponent;
  let fixture: ComponentFixture<ShipmentDetailViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShipmentDetailViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShipmentDetailViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
