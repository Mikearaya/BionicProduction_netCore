import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyProfileViewComponent } from './company-profile-view.component';

describe('CompanyProfileViewComponent', () => {
  let component: CompanyProfileViewComponent;
  let fixture: ComponentFixture<CompanyProfileViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompanyProfileViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyProfileViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
