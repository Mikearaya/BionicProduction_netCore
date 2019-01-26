import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemRoleViewComponent } from './system-role-view.component';

describe('SystemRoleViewComponent', () => {
  let component: SystemRoleViewComponent;
  let fixture: ComponentFixture<SystemRoleViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SystemRoleViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemRoleViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
