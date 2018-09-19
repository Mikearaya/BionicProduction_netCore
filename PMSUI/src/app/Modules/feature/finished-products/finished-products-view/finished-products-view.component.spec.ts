import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinishedProductsViewComponent } from './finished-products-view.component';

describe('FinishedProductsViewComponent', () => {
  let component: FinishedProductsViewComponent;
  let fixture: ComponentFixture<FinishedProductsViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinishedProductsViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinishedProductsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
