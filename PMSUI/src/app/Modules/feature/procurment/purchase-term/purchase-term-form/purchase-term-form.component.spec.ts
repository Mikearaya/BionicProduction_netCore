import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseTermFormComponent } from './purchase-term-form.component';

describe('PurchaseTermFormComponent', () => {
  let component: PurchaseTermFormComponent;
  let fixture: ComponentFixture<PurchaseTermFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseTermFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseTermFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
