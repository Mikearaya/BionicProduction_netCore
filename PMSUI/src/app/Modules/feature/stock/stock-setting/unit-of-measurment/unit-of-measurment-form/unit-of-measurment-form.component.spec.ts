import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnitOfMeasurmentFormComponent } from './unit-of-measurment-form.component';

describe('UnitOfMeasurmentFormComponent', () => {
  let component: UnitOfMeasurmentFormComponent;
  let fixture: ComponentFixture<UnitOfMeasurmentFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnitOfMeasurmentFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnitOfMeasurmentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
