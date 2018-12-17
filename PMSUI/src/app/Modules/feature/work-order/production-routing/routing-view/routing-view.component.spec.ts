import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoutingViewComponent } from './routing-view.component';

describe('RoutingViewComponent', () => {
  let component: RoutingViewComponent;
  let fixture: ComponentFixture<RoutingViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoutingViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoutingViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
