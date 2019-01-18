import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WriteOffFormComponent } from './write-off-form.component';

describe('WriteOffFormComponent', () => {
  let component: WriteOffFormComponent;
  let fixture: ComponentFixture<WriteOffFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WriteOffFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WriteOffFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
