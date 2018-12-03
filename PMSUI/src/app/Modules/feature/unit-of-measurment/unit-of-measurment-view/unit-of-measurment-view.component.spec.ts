import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnitOfMeasurmentViewComponent } from './unit-of-measurment-view.component';

describe('UnitOfMeasurmentViewComponent', () => {
  let component: UnitOfMeasurmentViewComponent;
  let fixture: ComponentFixture<UnitOfMeasurmentViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnitOfMeasurmentViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnitOfMeasurmentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
