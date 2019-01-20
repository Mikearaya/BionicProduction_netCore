import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PurchaseOrderApiService } from '../purchase-order-api.service';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { VendorApiService } from 'src/app/Modules/core/services/vendor/vendor-api.service';
import { VendorViewModel } from 'src/app/Modules/core/DataModels/vendor-data.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NewPurchaseOrderModel, PurchaseOrderDetailView, PurchaseOrderItemModel, PurchaseOrderItemView } from '../pruchse-order-data.model';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';


@Component({
  selector: 'app-purchase-order-form',
  templateUrl: './purchase-order-form.component.html',
  styleUrls: ['./purchase-order-form.component.css']
})
export class PurchaseOrderFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;

  public purchaseOrderForm: FormGroup;
  public title: string;
  public isUpdate: Boolean;
  public purchaseOrderStatus = ['New', 'RFQ'];
  public itemsList: ItemView[];
  public itemFields: { text: string, value: string };

  public vendorsList: VendorViewModel[];
  public vendorFields: { text: string, value: string };

  private purchaseOrderId: number;

  constructor(private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private purchaseOrderApi: PurchaseOrderApiService,
    private itemApi: ItemApiService,
    private vendorApi: VendorApiService) {
    super();
    this.createForm();
    this.itemFields = { text: 'name', value: 'id' };
    this.vendorFields = { text: 'name', value: 'id' };
  }

  ngOnInit() {
    this.purchaseOrderId = + this.activatedRoute.snapshot.paramMap.get('purchaseOrderId');
    this.title = this.activatedRoute.snapshot.data['title'];

    this.vendorApi.getAllVendors().subscribe(
      (data: VendorViewModel[]) => this.vendorsList = data,
      this.handleError
    );

    if (this.purchaseOrderId) {
      this.isUpdate = true;
      this.purchaseOrderApi.getPurchaseOrderById(this.purchaseOrderId).subscribe(
        (data: PurchaseOrderDetailView) => this.initializeForm(data),
        this.handleError
      );
    }
  }


  vendorChanged(event: any) {
    this.itemApi.getVendorItems(event.value).subscribe(
      (data: any[]) => this.itemsList = data
    );
  }

  private createForm(): void {
    this.purchaseOrderForm = this.formBuilder.group({
      vendorId: ['', Validators.required],
      status: ['', Validators.required],
      expectedDate: ['', Validators.required],
      tax: [''],
      discount: [''],
      additionalFees: [''],
      note: [''],
      orderId: [''],
      orderDate: [''],
      invoiceId: [''],
      invoiceDate: [''],
      paymentDate: [''],
      shippedOn: [''],
      arrivalDate: [''],
      purchaseOrderItems: this.formBuilder.array([this.createPurchaseOrderItems()])

    });
  }

  private initializeForm(data: PurchaseOrderDetailView): void {

    const vendor = { value: data.vendorId };

    this.vendorChanged(vendor);

    this.purchaseOrderForm = this.formBuilder.group({
      vendorId: [data.vendorId, Validators.required],
      status: [data.status, Validators.required],
      expectedDate: [data.expectedDate, Validators.required],
      tax: [data.tax],
      discount: [data.discount],
      additionalFees: [data.additionalFee],
      note: [''],
      orderId: [data.orderId],
      orderDate: [data.orderedDate],
      invoiceId: [data.invoiceId],
      invoiceDate: [data.invoiceDate],
      paymentDate: [data.paymentDate],
      shippedOn: [data.shippedDate],
      arrivalDate: [''],
      purchaseOrderItems: this.formBuilder.array(data.OrderItems.map(i => this.initializePurchaseOrderItems(i)))

    });
  }

  get vendorId(): FormControl {
    return this.purchaseOrderForm.get('vendorId') as FormControl;
  }

  get status(): FormControl {
    return this.purchaseOrderForm.get('status') as FormControl;
  }
  get expectedDate(): FormControl {
    return this.purchaseOrderForm.get('expectedDate') as FormControl;
  }

  get tax(): FormControl {
    return this.purchaseOrderForm.get('tax') as FormControl;
  }

  get discount(): FormControl {
    return this.purchaseOrderForm.get('discount') as FormControl;
  }
  get additionalFees(): FormControl {
    return this.purchaseOrderForm.get('additionalFees') as FormControl;
  }

  get note(): FormControl {
    return this.purchaseOrderForm.get('note') as FormControl;
  }
  get orderId(): FormControl {
    return this.purchaseOrderForm.get('orderId') as FormControl;
  }

  get orderDate(): FormControl {
    return this.purchaseOrderForm.get('orderDate') as FormControl;
  }

  get invoiceId(): FormControl {
    return this.purchaseOrderForm.get('invoiceId') as FormControl;
  }

  get invoiceDate(): FormControl {
    return this.purchaseOrderForm.get('invoiceDate') as FormControl;
  }
  get paymentDate(): FormControl {
    return this.purchaseOrderForm.get('paymentDate') as FormControl;
  }

  get shippedOn(): FormControl {
    return this.purchaseOrderForm.get('shippedOn') as FormControl;
  }

  get arrivalDate(): FormControl {
    return this.purchaseOrderForm.get('arrivalDate') as FormControl;
  }

  get purchaseOrderItems(): FormArray {
    return this.purchaseOrderForm.get('purchaseOrderItems') as FormArray;
  }


  initializePurchaseOrderItems(data: PurchaseOrderItemView): FormGroup {
    return this.formBuilder.group({
      itemId: [data.itemId, Validators.required],
      quantity: [data.quantity, Validators.required],
      unitPrice: [data.unitPrice],
      expectedDate: [data.expectedDate]
    });
  }

  private createPurchaseOrderItems(): FormGroup {
    return this.formBuilder.group({
      itemId: ['', Validators.required],
      quantity: ['', Validators.required],
      unitPrice: [''],
      expectedDate: ['']
    });
  }

  addPurchaseOrderItem(): void {
    this.purchaseOrderItems.push(this.createPurchaseOrderItems());
  }

  removePurchaseOrderItem(index: number): void {
    this.purchaseOrderItems.removeAt(index);
  }

  onSubmit(): void {
    if (this.purchaseOrderForm.valid) {
      if (!this.isUpdate) {
        const purchaseOrder = this.prepareNewPurchaseOrderData();

        this.purchaseOrderApi.createPurchaseOrder(purchaseOrder).subscribe(
          (data: PurchaseOrderDetailView) => {
            this.notification.showMessage('Purchase order created successfully');
            this.isUpdate = true;
            this.purchaseOrderId = data.id;
          }
        );
      }
    }
  }

  private prepareNewPurchaseOrderData(): NewPurchaseOrderModel {
    const newPurchaseOrder = new NewPurchaseOrderModel();
    newPurchaseOrder.VendorId = this.vendorId.value;
    newPurchaseOrder.Status = this.status.value;
    newPurchaseOrder.ExpectedDate = this.expectedDate.value;
    newPurchaseOrder.Tax = this.tax.value;
    newPurchaseOrder.Discount = this.discount.value;
    newPurchaseOrder.AdditionalFee = this.additionalFees.value;
    newPurchaseOrder.OrderId = this.orderId.value;
    newPurchaseOrder.OrderedDate = this.orderDate.value;
    newPurchaseOrder.InvoiceId = this.invoiceId.value;
    newPurchaseOrder.InvoiceDate = this.invoiceDate.value;
    newPurchaseOrder.PaymentDate = this.paymentDate.value;
    newPurchaseOrder.ShippedDate = this.shippedOn.value;

    this.purchaseOrderItems.controls.forEach(element => {
      newPurchaseOrder.PurchaseOrderItems.push(
        {
          ExpectedDate: element.value.expectedDate,
          ItemId: element.value.itemId,
          Quantity: element.value.quantity,
          UnitPrice: element.value.unitPrice,
          Id: 0
        }
      );
    });

    return newPurchaseOrder;

  }


}
