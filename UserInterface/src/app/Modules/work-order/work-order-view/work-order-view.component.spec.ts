/*
 * @CreateTime: Sep 12, 2018 12:48 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 12, 2018 12:48 AM
 * @Description: Modify Here, Please
 */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkOrderViewComponent } from './work-order-view.component';

describe('WorkOrderViewComponent', () => {
  let component: WorkOrderViewComponent;
  let fixture: ComponentFixture<WorkOrderViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkOrderViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkOrderViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
