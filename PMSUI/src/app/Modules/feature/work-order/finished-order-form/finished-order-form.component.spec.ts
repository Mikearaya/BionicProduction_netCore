import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinishedOrderFormComponent } from './finished-order-form.component';

describe('FinishedOrderFormComponent', () => {
  let component: FinishedOrderFormComponent;
  let fixture: ComponentFixture<FinishedOrderFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinishedOrderFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinishedOrderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
