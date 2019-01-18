/*
 * @CreateTime: Sep 5, 2018 8:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 5, 2018 8:46 PM
 * @Description: Modify Here, Please
 */

import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerViewComponent } from './customer-view.component';

describe('CustomerViewComponent', () => {
  let component: CustomerViewComponent;
  let fixture: ComponentFixture<CustomerViewComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
