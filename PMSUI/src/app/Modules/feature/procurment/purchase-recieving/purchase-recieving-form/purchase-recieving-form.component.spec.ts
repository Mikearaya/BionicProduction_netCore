import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseRecievingFormComponent } from './purchase-recieving-form.component';

describe('PurchaseRecievingFormComponent', () => {
  let component: PurchaseRecievingFormComponent;
  let fixture: ComponentFixture<PurchaseRecievingFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseRecievingFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseRecievingFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
