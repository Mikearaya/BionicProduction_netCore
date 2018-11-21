import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnualSaleChartComponent } from './anual-sale-chart.component';

describe('AnualSaleChartComponent', () => {
  let component: AnualSaleChartComponent;
  let fixture: ComponentFixture<AnualSaleChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnualSaleChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnualSaleChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
