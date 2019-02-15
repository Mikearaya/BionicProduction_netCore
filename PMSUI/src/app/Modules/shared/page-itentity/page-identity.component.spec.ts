import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageIdentityComponent } from './page-identity.component';

describe('PageIdentityComponent', () => {
  let component: PageIdentityComponent;
  let fixture: ComponentFixture<PageIdentityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PageIdentityComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageIdentityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
