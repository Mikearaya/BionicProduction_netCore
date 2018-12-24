import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseTermViewComponent } from './purchase-term-view.component';

describe('PurchaseTermViewComponent', () => {
  let component: PurchaseTermViewComponent;
  let fixture: ComponentFixture<PurchaseTermViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseTermViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseTermViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
