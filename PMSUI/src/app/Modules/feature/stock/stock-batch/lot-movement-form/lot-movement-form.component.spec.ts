import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LotMovementFormComponent } from './lot-movement-form.component';

describe('LotMovementFormComponent', () => {
  let component: LotMovementFormComponent;
  let fixture: ComponentFixture<LotMovementFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LotMovementFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LotMovementFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
