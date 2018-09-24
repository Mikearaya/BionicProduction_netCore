import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CurrentStockViewComponent } from './current-stock-view.component';



describe('CurrentStockViewComponent', () => {
  let component: CurrentStockViewComponent;
  let fixture: ComponentFixture<CurrentStockViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentStockViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentStockViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
