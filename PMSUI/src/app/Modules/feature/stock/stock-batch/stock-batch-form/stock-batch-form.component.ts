import { ActivatedRoute, Router } from '@angular/router';
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
import {
  NewStockBatchModel,
  StockBatchDetailView,
  StockBatchStorageView,
  UpdatedStockBatchModel
} from 'src/app/Modules/core/DataModels/stock-batch.model';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { StorageLocationApiService } from 'src/app/Modules/core/services/storage-location/storage-location-api.service';
import { StorageLocationView } from 'src/app/Modules/core/DataModels/storage-location.model';
import { StockBatchApiService } from 'src/app/Modules/core/services/stock-batch/stock-batch-api.service';

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
  public stockBatchStatus = ['Recieved', 'Planed', 'Canceled'];
  public itemsList: ItemView[] = [];
  public itemField: { text: string, value: string };
  public storesList: StorageLocationView[] = [];
  public storageField: { text: string, value: string };

  private stockBatchId: number;

  constructor(private stockBatchApi: StockBatchApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private itemApi: ItemApiService,
    private storageApi: StorageLocationApiService,
    private router: Router) {
    super();
    this.itemField = { text: 'name', value: 'id' };
    this.storageField = { text: 'name', value: 'id' };
    this.createForm();
  }

  ngOnInit() {
    this.stockBatchId = + this.activatedRoute.snapshot.paramMap.get('stockBatchId');

    this.title = 'Create new stock batch';
    this.isUpdate = false;
    this.submitButtonText = 'Create';

    this.itemApi.getAllItems().subscribe(
      (data: ItemView[]) => this.itemsList = data,
      this.handleError
    );

    this.storageApi.getAllStorageLocations().subscribe(
      (data: StorageLocationView[]) => this.storesList = data,
      this.handleError
    );


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
      expiryDate: [''],
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
      expiryDate: [batch.expiryDate],
      unitCost: [batch.unitCost, Validators.required],
      storageLocation: this.formBuilder.array(batch.storages.map(store => this.initializeStorageLocation(store)))

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


  moveStockLot(index: number): void {
    this.router.navigate([`stocks/stock-lots/${this.stockBatchId}/movements`]);
  }

  onSubmit(): void {

    if (!this.isUpdate) {
      const stockBatch = this.prepareNewFormData();

      if (stockBatch) {
        this.stockBatchApi.createNewStockBatch(stockBatch).subscribe(
          (data: StockBatchDetailView) => {
            this.notification.showMessage('Stock Batch Created Successfuly');
            this.title = `Update Stock Batch ${data.id}`;
            this.submitButtonText = 'Update';
            this.initializeForm(data);
            this.isUpdate = true;
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Something Wrong Happened While Creating Batch, Try Again', 'error');
            this.handleError(error);
          }
        );
      }

    } else if (this.isUpdate) {
      const stockBatch = this.prepareUpdatedFormData();

      this.stockBatchApi.updateStockBatch(stockBatch).subscribe(
        () => this.notification.showMessage('Stock Batch Updated Successfuly'),
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Something Wrong Happened While Updating Batch, Try Again', 'error');
          this.handleError(error);
        }
      );
    }


  }


  addStorage(): void {
    this.storageLocation.controls.push(this.createStorageLocation());
  }

  deleteStorage(index: number): void {
    this.storageLocation.removeAt(index);
  }

  private prepareNewFormData(): NewStockBatchModel | null {

    if (this.stockBatchForm.valid && !this.isUpdate) {
      const newBatch = new NewStockBatchModel();
      newBatch.ItemId = this.itemId.value;
      newBatch.Quantity = this.quantity.value;
      newBatch.Status = this.status.value;
      newBatch.AvailableFrom = this.availableFrom.value,
        newBatch.UnitCost = this.unitCost.value;
      newBatch.ExpiryDate = this.expiryDate.value;
      this.storageLocation.value.map(store => newBatch.StorageLocation.push({
        StorageId: store.storageId,
        Quantity: store.quantity
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
        Status: this.status.value,
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
