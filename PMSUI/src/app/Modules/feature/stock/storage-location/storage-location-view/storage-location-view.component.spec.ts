import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorageLocationViewComponent } from './storage-location-view.component';

describe('StorageLocationViewComponent', () => {
  let component: StorageLocationViewComponent;
  let fixture: ComponentFixture<StorageLocationViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StorageLocationViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StorageLocationViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
