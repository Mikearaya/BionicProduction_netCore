import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionStatusChartComponent } from './production-status-chart.component';

describe('ProductionStatusChartComponent', () => {
  let component: ProductionStatusChartComponent;
  let fixture: ComponentFixture<ProductionStatusChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductionStatusChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionStatusChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
