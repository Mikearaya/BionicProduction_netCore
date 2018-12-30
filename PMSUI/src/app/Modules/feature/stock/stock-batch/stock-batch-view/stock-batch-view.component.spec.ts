import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StockBatchViewComponent } from './stock-batch-view.component';

describe('StockBatchViewComponent', () => {
  let component: StockBatchViewComponent;
  let fixture: ComponentFixture<StockBatchViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StockBatchViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockBatchViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
