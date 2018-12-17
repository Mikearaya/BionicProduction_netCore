import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoutingFormComponent } from './routing-form.component';

describe('RoutingFormComponent', () => {
  let component: RoutingFormComponent;
  let fixture: ComponentFixture<RoutingFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoutingFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoutingFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
