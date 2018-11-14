import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentViewComponent } from './shipment-view.component';

describe('ShipmentViewComponent', () => {
  let component: ShipmentViewComponent;
  let fixture: ComponentFixture<ShipmentViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShipmentViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShipmentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
