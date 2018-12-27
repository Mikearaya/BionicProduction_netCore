import { Component, OnInit, ViewChild } from '@angular/core';
import { PurchaseTermApiService } from '../../../../core/services/purchase-terms/purchase-term-api.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { PurchaseTermViewModel, PurchaseTermModel } from 'src/app/Modules/core/DataModels/purchase-terms-data.model';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { VendorApiService } from '../../../../core/services/vendor/vendor-api.service';
import { Location } from '@angular/common';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { VendorViewModel } from 'src/app/Modules/core/DataModels/vendor-data.model';

@Component({
  selector: 'app-purchase-term-form',
  templateUrl: './purchase-term-form.component.html',
  styleUrls: ['./purchase-term-form.component.css']
})
export class PurchaseTermFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification')
  public notification: NotificationComponent;

  private termId: number;
  public isUpdate: Boolean;
  public title: string;
  public submitButtonText: string;
  public purchaseTermForm: FormGroup;
  public itemsList: ItemView[] = [];
  public itemFields: { text: string, value: string };
  public vendorsList: VendorViewModel[] = [];
  public vendorFields: { text: string, value: string };

  constructor(private purchaseTermApi: PurchaseTermApiService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private itemApi: ItemApiService,
    private vendorApi: VendorApiService,
    private location: Location) {
    super();
    this.vendorFields = { text: 'name', value: 'id' };
    this.itemFields = { text: 'name', value: 'id' };
    this.createForm();


  }

  ngOnInit() {

    this.termId = + this.activatedRoute.snapshot.paramMap.get('purchaseTermId');

    this.isUpdate = false;
    this.title = 'Create Vendor Purchase Term';
    this.submitButtonText = 'Save';


    this.itemApi.getAllItems().subscribe(
      (data: ItemView[]) => this.itemsList = data,
      this.handleError
    );

    this.vendorApi.getAllVendors().subscribe(
      (data: VendorViewModel[]) => this.vendorsList = data,
      this.handleError
    );

    if (this.termId) {
      this.isUpdate = true;
      this.title = `Update Vendor Purchase Term #${this.termId}`;
      this.submitButtonText = 'Update';

      this.purchaseTermApi.getPurchaseTermById(this.termId).subscribe(
        (data: PurchaseTermViewModel) => this.initializeForm(data),
        this.handleError
      );
    }

  }

  private createForm(): void {
    this.purchaseTermForm = this.formBuilder.group({
      vendorId: ['', Validators.required],
      itemId: ['', Validators.required],
      vendorProductId: [''],
      priority: ['', Validators.pattern('[0-9]*')],
      leadTime: [''],
      minimumQuantity: [''],
      unitPrice: ['', Validators.required],
    });
  }


  private initializeForm(term: PurchaseTermViewModel): void {
    this.purchaseTermForm = this.formBuilder.group({
      vendorId: [term.vendorId, Validators.required],
      itemId: [term.itemId, Validators.required],
      vendorProductId: [term.vendorProductId],
      priority: [term.priority],
      leadTime: [term.leadtime],
      minimumQuantity: [term.minimumQuantity],
      unitPrice: [term.unitPrice, Validators.required],
    });
  }

  get vendorId(): FormControl {
    return this.purchaseTermForm.get('vendorId') as FormControl;
  }

  get itemId(): FormControl {
    return this.purchaseTermForm.get('itemId') as FormControl;
  }

  get vendorProductId(): FormControl {
    return this.purchaseTermForm.get('vendorProductId') as FormControl;
  }

  get priority(): FormControl {
    return this.purchaseTermForm.get('priority') as FormControl;
  }

  get leadTime(): FormControl {
    return this.purchaseTermForm.get('leadTime') as FormControl;
  }

  get minimumQuantity(): FormControl {
    return this.purchaseTermForm.get('minimumQuantity') as FormControl;
  }

  get unitPrice(): FormControl {
    return this.purchaseTermForm.get('unitPrice') as FormControl;
  }


  onSubmit(): void {
    const purchaseTerm = this.prepareFormData();

    if (this.isUpdate && purchaseTerm) {

      this.purchaseTermApi.updatePurchaseTerm(purchaseTerm.id, purchaseTerm).subscribe(
        () => this.notification.showMessage('Purchase term Updated!!!'),
        this.handleError
      );
    } else {
      this.purchaseTermApi.createPurchaseTerm(purchaseTerm).subscribe(
        () => {
          this.notification.showMessage('Purchase term Created!!!');
          this.purchaseTermForm.reset();
        },
        this.handleError
      );
    }

  }

  private prepareFormData(): PurchaseTermModel | null {
    const purchaseTerm = new PurchaseTermModel();

    if (this.purchaseTermForm.valid) {
      purchaseTerm.id = (this.termId) ? this.termId : 0;
      purchaseTerm.vendorId = this.vendorId.value;
      purchaseTerm.itemId = this.itemId.value;
      purchaseTerm.vendorProductId = this.vendorProductId.value;
      purchaseTerm.priority = this.priority.value;
      purchaseTerm.leadtime = this.leadTime.value;
      purchaseTerm.minimumQuantity = this.minimumQuantity.value;
      purchaseTerm.unitPrice = this.unitPrice.value;

      return purchaseTerm;

    } else {
      return null;
    }

  }

  deletePurchaseTerm(): void {
    if (this.isUpdate) {
      this.purchaseTermApi.deletePurchaseTerm(this.termId).subscribe(
        () => {
          this.location.back();
          this.notification.showMessage('Purchase Term Removed Successfuly');
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Unable to delete Purchase Term Try Again Later!!', 'error');
          this.handleError(error);
        }
      );
    }
  }


}
