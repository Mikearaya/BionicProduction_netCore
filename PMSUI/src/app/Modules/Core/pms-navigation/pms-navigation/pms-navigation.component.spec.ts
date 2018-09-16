import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PmsNavigationComponent } from './pms-navigation.component';

describe('PmsNavigationComponent', () => {
  let component: PmsNavigationComponent;
  let fixture: ComponentFixture<PmsNavigationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PmsNavigationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PmsNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
