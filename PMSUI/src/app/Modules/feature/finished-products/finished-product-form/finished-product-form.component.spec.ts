import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinishedProductFormComponent } from './finished-product-form.component';

describe('FinishedProductFormComponent', () => {
  let component: FinishedProductFormComponent;
  let fixture: ComponentFixture<FinishedProductFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinishedProductFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinishedProductFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
