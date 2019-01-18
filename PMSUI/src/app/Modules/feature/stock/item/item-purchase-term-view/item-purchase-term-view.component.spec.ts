import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemPurchaseTermViewComponent } from './item-purchase-term-view.component';

describe('ItemPurchaseTermViewComponent', () => {
  let component: ItemPurchaseTermViewComponent;
  let fixture: ComponentFixture<ItemPurchaseTermViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemPurchaseTermViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemPurchaseTermViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
