import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingOrdersViewComponent } from './pending-orders-view.component';

describe('PendingOrdersViewComponent', () => {
  let component: PendingOrdersViewComponent;
  let fixture: ComponentFixture<PendingOrdersViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PendingOrdersViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PendingOrdersViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
