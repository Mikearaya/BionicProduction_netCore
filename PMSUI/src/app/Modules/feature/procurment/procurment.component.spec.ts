import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcurmentComponent } from './procurment.component';

describe('ProcurmentComponent', () => {
  let component: ProcurmentComponent;
  let fixture: ComponentFixture<ProcurmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProcurmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcurmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
