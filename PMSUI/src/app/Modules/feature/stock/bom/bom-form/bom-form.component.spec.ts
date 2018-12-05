import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BomFormComponent } from './bom-form.component';

describe('BomFormComponent', () => {
  let component: BomFormComponent;
  let fixture: ComponentFixture<BomFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BomFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BomFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
