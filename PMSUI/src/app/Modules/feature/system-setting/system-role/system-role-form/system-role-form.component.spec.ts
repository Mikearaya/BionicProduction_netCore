import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemRoleFormComponent } from './system-role-form.component';

describe('SystemRoleFormComponent', () => {
  let component: SystemRoleFormComponent;
  let fixture: ComponentFixture<SystemRoleFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SystemRoleFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemRoleFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
