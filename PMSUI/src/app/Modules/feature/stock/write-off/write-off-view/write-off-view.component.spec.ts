import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WriteOffViewComponent } from './write-off-view.component';

describe('WriteOffViewComponent', () => {
  let component: WriteOffViewComponent;
  let fixture: ComponentFixture<WriteOffViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WriteOffViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WriteOffViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
