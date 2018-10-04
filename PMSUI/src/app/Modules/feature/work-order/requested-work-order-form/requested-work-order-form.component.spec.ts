import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestedWorkOrderFormComponent } from './requested-work-order-form.component';

describe('RequestedWorkOrderFormComponent', () => {
  let component: RequestedWorkOrderFormComponent;
  let fixture: ComponentFixture<RequestedWorkOrderFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestedWorkOrderFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestedWorkOrderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
