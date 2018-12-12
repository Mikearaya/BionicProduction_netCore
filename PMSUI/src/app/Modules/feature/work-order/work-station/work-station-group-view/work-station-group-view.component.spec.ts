import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkStationGroupViewComponent } from './work-station-group-view.component';

describe('WorkStationGroupViewComponent', () => {
  let component: WorkStationGroupViewComponent;
  let fixture: ComponentFixture<WorkStationGroupViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkStationGroupViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkStationGroupViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
