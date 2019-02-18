import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseRecievingViewComponent } from './purchase-recieving-view.component';

describe('PurchaseRecievingViewComponent', () => {
  let component: PurchaseRecievingViewComponent;
  let fixture: ComponentFixture<PurchaseRecievingViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseRecievingViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseRecievingViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
