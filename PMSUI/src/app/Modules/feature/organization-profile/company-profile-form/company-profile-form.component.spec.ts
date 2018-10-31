import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyProfileFormComponent } from './company-profile-form.component';

describe('CompanyProfileFormComponent', () => {
  let component: CompanyProfileFormComponent;
  let fixture: ComponentFixture<CompanyProfileFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompanyProfileFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyProfileFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
