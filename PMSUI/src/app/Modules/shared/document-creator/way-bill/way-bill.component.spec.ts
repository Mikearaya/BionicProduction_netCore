import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WayBillComponent } from './way-bill.component';

describe('WayBillComponent', () => {
  let component: WayBillComponent;
  let fixture: ComponentFixture<WayBillComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WayBillComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WayBillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
