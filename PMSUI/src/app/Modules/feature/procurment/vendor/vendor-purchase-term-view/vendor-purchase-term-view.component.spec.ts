import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { VendorPurchaseTermViewComponent } from './vendor-purchase-term-view.component';



describe('VendorPurchaseTermViewComponent', () => {
  let component: VendorPurchaseTermViewComponent;
  let fixture: ComponentFixture<VendorPurchaseTermViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [VendorPurchaseTermViewComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorPurchaseTermViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
