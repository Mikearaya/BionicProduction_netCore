
import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeViewComponent } from './employee-view.component';

describe('EmployeeViewComponent', () => {
  let component: EmployeeViewComponent;
  let fixture: ComponentFixture<EmployeeViewComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
