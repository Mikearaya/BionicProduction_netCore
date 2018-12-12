import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkStationGroupFormComponent } from './work-station-group-form.component';

describe('WorkStationGroupFormComponent', () => {
  let component: WorkStationGroupFormComponent;
  let fixture: ComponentFixture<WorkStationGroupFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkStationGroupFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkStationGroupFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
