import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { VendorViewModel } from 'src/app/Modules/core/DataModels/vendor-data.model';
import { ActivatedRoute } from '@angular/router';
import { PurchaseOrderApiService } from '../../purchase-order-api.service';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { VendorApiService } from 'src/app/Modules/core/services/vendor/vendor-api.service';
import { PurchaseOrderDetailView, PurchaseOrderItemView, NewPurchaseOrderModel } from '../../purchase-order/pruchse-order-data.model';
import { PurchaseRecievingModel } from '../purchase-recieving-data.model';

@Component({
  selector: 'app-purchase-recieving-form',
  templateUrl: './purchase-recieving-form.component.html',
  styleUrls: ['./purchase-recieving-form.component.css']
})
export class PurchaseRecievingFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;

  public purchaseOrderForm: FormGroup;
  public purchaseOrder: PurchaseOrderDetailView;
  public title: string;
  public isUpdate: Boolean;
  public purchaseOrderStatus = ['New', 'RFQ', 'Ordered', 'Shipped', 'Recieved', 'Canceled'];
  public itemsList: ItemView[];
  public itemFields: { text: string, value: string };

  public vendorsList: VendorViewModel[];
  public vendorFields: { text: string, value: string };

  private purchaseOrderId: number;
  totalBeforeDiscount: number;
  total: number;
  totalAfterTax: number;
  totalAfterAdditionalFee: number;

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

    if (this.purchaseOrderId) {
      this.purchaseOrderApi.getPurchaseOrderById(this.purchaseOrderId).subscribe(
        (data: PurchaseOrderDetailView) => this.initializeForm(data),
        this.handleError
      );
    }
  }


  private createForm(): void {
    this.purchaseOrderForm = this.formBuilder.group({
      purchaseOrderItems: this.formBuilder.array([this.createPurchaseOrderItems()])

    });

  }


  private initializeForm(data: PurchaseOrderDetailView): void {
    this.purchaseOrder = data;

    this.purchaseOrderForm = this.formBuilder.group({
      purchaseOrderItems: this.formBuilder.array(data.OrderItems.map(i => this.initializePurchaseOrderItems(i)))

    });
  }

  get purchaseOrderItems(): FormArray {
    return this.purchaseOrderForm.get('purchaseOrderItems') as FormArray;
  }


  initializePurchaseOrderItems(data: PurchaseOrderItemView): FormGroup {
    return this.formBuilder.group({
      lotId: [data.lotId, Validators.required],
      recieved: [(data.status.toUpperCase() === 'RECIEVED') ? 0 : data.quantity, Validators.required]
    });
  }
  selectedItemUnitPrice(index: number): FormControl {
    return this.purchaseOrderItems.controls[index].get('unitPrice') as FormControl;
  }

  selectedItemId(index: number): FormControl {
    return this.purchaseOrderItems.controls[index].get('itemId') as FormControl;
  }

  selectedItemQuantity(index: number): FormControl {
    return this.purchaseOrderItems.controls[index].get('quantity') as FormControl;
  }

  selectedItemExpectedDate(index: number): FormControl {
    return this.purchaseOrderItems.controls[index].get('expectedDate') as FormControl;
  }

  private createPurchaseOrderItems(): FormGroup {
    return this.formBuilder.group({
      lotId: ['', Validators.required],
      recieved: ['', Validators.required]
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
      const purchaseOrder = this.prepareNewPurchaseOrderData();
      this.purchaseOrderApi.addNewPurchaseRecieving(purchaseOrder).subscribe(
        (data: PurchaseOrderDetailView) => {
          this.notification.showMessage('Purchase order items recieved successfully');
          this.isUpdate = true;
          this.purchaseOrderId = data.id;
          this.initializeForm(data);
        }
      );
    }
  }


  private prepareNewPurchaseOrderData(): PurchaseRecievingModel {
    const newPurchaseOrder = new PurchaseRecievingModel();
    newPurchaseOrder.PurchaseOrderId = this.purchaseOrderId;
    this.purchaseOrderItems.controls.forEach(element => {
      newPurchaseOrder.RecievedItems.push(
        {
          LotId: element.value.lotId,
          Quantity: element.value.recieved
        }
      );
    });

    return newPurchaseOrder;

  }



}
