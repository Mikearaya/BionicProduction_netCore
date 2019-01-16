import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemBomListViewComponent } from './item-bom-list-view.component';

describe('ItemBomListViewComponent', () => {
  let component: ItemBomListViewComponent;
  let fixture: ComponentFixture<ItemBomListViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemBomListViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemBomListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
