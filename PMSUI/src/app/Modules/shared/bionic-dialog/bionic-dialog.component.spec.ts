import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BionicDialogComponent } from './bionic-dialog.component';

describe('BionicDialogComponent', () => {
  let component: BionicDialogComponent;
  let fixture: ComponentFixture<BionicDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BionicDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BionicDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
