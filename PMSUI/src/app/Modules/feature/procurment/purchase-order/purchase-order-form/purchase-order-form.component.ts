import { Component, OnInit } from '@angular/core';
import { FormBuilder, Form, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PurchaseOrderApiService } from '../purchase-order-api.service';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { VendorApiService } from 'src/app/Modules/core/services/vendor/vendor-api.service';
import { VendorViewModel } from 'src/app/Modules/core/DataModels/vendor-data.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-purchase-order-form',
  templateUrl: './purchase-order-form.component.html',
  styleUrls: ['./purchase-order-form.component.css']
})
export class PurchaseOrderFormComponent extends CommonProperties implements OnInit {

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
    private purchaseOorderApi: PurchaseOrderApiService,
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
    }
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

  }


}
