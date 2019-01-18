import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StockSettingComponent } from './stock-setting.component';

describe('StockSettingComponent', () => {
  let component: StockSettingComponent;
  let fixture: ComponentFixture<StockSettingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StockSettingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
