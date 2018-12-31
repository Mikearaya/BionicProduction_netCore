import { ActivatedRoute } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { Location } from '@angular/common';
import {
  NewStockBatchModel,
  StockBatchDetailView,
  StockBatchStorageView,
  UpdatedStockBatchModel
} from 'src/app/Modules/core/DataModels/stock-batch.model';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { StockBatchApiService } from '../stock-batch-api.service';

@Component({
  selector: 'app-stock-batch-form',
  templateUrl: './stock-batch-form.component.html',
  styleUrls: ['./stock-batch-form.component.css']
})
export class StockBatchFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;

  public stockBatchForm: FormGroup;
  public isUpdate: Boolean;
  public title: string;
  public submitButtonText: string;
  private stockBatchId: number;

  constructor(private stockBatchApi: StockBatchApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute) {
    super();

    this.createForm();
  }

  ngOnInit() {
    this.stockBatchId = + this.activatedRoute.snapshot.paramMap.get('stockBatchId');

    this.title = 'Create new stock batch';
    this.isUpdate = false;
    this.submitButtonText = 'Create';

    if (this.stockBatchId) {
      this.isUpdate = true;
      this.title = `Update Stock Batch ${this.stockBatchId}`;
      this.submitButtonText = 'Update';

      this.stockBatchApi.getStockBatchById(this.stockBatchId).subscribe(
        (data: StockBatchDetailView) => this.initializeForm(data),
        this.handleError
      );

    }
  }

  private createForm(): void {
    this.stockBatchForm = this.formBuilder.group({
      itemId: ['', Validators.required],
      status: ['', Validators.required],
      quantity: ['', Validators.required],
      availableFrom: ['', Validators.required],
      expiryDate: ['', Validators.required],
      unitCost: ['', Validators.required],
      storageLocation: this.formBuilder.array([this.createStorageLocation()])

    });
  }

  private createStorageLocation(): FormGroup {
    return this.formBuilder.group({
      storageId: ['', Validators.required],
      quantity: ['', Validators.required]
    });
  }

  private initializeForm(batch: StockBatchDetailView): void {
    this.stockBatchForm = this.formBuilder.group({
      id: [batch.id, Validators.required],
      itemId: [batch.itemId, Validators.required],
      status: [batch.status, Validators.required],
      quantity: [batch.quantity, Validators.required],
      availableFrom: [batch.availableFrom, Validators.required],
      expiryDate: [batch.expiryDate, Validators.required],
      unitCost: [batch.unitCost, Validators.required],
      storageLocation: this.formBuilder.array([batch.storages.map(store => this.initializeStorageLocation(store))])

    });
  }


  private initializeStorageLocation(storage: StockBatchStorageView): FormGroup {
    return this.formBuilder.group({
      id: [storage.id, Validators.required],
      storageId: [storage.storageId, Validators.required],
      quantity: [storage.quantity, Validators.required]
    });
  }


  get itemId(): FormControl {
    return this.stockBatchForm.get('itemId') as FormControl;
  }

  get status(): FormControl {
    return this.stockBatchForm.get('status') as FormControl;
  }


  get quantity(): FormControl {
    return this.stockBatchForm.get('quantity') as FormControl;
  }


  get availableFrom(): FormControl {
    return this.stockBatchForm.get('availableFrom') as FormControl;
  }

  get unitCost(): FormControl {
    return this.stockBatchForm.get('unitCost') as FormControl;
  }

  get expiryDate(): FormControl {
    return this.stockBatchForm.get('expiryDate') as FormControl;
  }
  get storageLocation(): FormArray {
    return this.stockBatchForm.get('storageLocation') as FormArray;
  }


  onSubmit(): void {

  }

  private prepareNewFormData(): NewStockBatchModel | null {

    if (this.stockBatchForm.valid && !this.isUpdate) {
      const newBatch = new NewStockBatchModel();
      newBatch.ItemId = this.itemId.value;
      newBatch.Quantity = this.quantity.value;
      newBatch.AvailableFrom = this.availableFrom.value,
        newBatch.UnitCost = this.unitCost.value;
      newBatch.ExpiryDate = this.expiryDate.value;
      this.storageLocation.value.map(store => newBatch.StorageLocation.push({
        StorageId: store.storageId.value,
        Quantity: store.quantity.value
      }));

      return newBatch;
    } else {
      return null;
    }
  }

  private prepareUpdatedFormData(): UpdatedStockBatchModel | null {

    if (this.stockBatchForm.valid && this.isUpdate && this.stockBatchId) {
      return {
        Id: this.stockBatchId,
        status: this.status.value,
        AvailableFrom: this.availableFrom.value,
        ExpiryDate: this.expiryDate.value
      };
    } else {
      return null;
    }
  }


  public deleteBatch(): void {
    if (this.isUpdate) {
      this.stockBatchApi.deleteStockBatch(this.stockBatchId).subscribe(
        () => {
          this.notification.showMessage('Stock Batch Deleted!!!');
          this.stockBatchForm.reset();
          this.createForm();
          this.title = 'Create New Stock Batch';
          this.submitButtonText = 'Create';
          this.isUpdate = false;
          this.stockBatchId = null;
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed While Tring to delete stock batch');
          this.handleError(error);
        }
      );
    } else {
      return null;
    }
  }



}
