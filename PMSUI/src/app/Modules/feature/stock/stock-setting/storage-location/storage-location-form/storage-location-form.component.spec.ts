import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorageLocationFormComponent } from './storage-location-form.component';

describe('StorageLocationFormComponent', () => {
  let component: StorageLocationFormComponent;
  let fixture: ComponentFixture<StorageLocationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StorageLocationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StorageLocationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
