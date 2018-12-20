import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemRoutingListViewComponent } from './item-routing-list-view.component';

describe('ItemRoutingListViewComponent', () => {
  let component: ItemRoutingListViewComponent;
  let fixture: ComponentFixture<ItemRoutingListViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemRoutingListViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemRoutingListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
