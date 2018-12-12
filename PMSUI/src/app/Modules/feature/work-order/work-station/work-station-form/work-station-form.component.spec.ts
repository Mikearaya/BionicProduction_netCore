import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkStationFormComponent } from './work-station-form.component';

describe('WorkStationFormComponent', () => {
  let component: WorkStationFormComponent;
  let fixture: ComponentFixture<WorkStationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkStationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkStationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
