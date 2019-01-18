import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorViewComponent } from './vendor-view.component';

describe('VendorViewComponent', () => {
  let component: VendorViewComponent;
  let fixture: ComponentFixture<VendorViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
