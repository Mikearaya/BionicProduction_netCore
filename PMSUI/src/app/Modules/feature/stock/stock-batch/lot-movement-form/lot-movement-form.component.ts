import { ActivatedRoute } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { Location } from '@angular/common';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { StockBatchApiService } from 'src/app/Modules/core/services/stock-batch/stock-batch-api.service';
import {
  StockBatchDetailView,
  StockBatchListView,
  StockBatchStorageView,
  StockLotMovementModel
} from 'src/app/Modules/core/DataModels/stock-batch.model';
import { StorageLocationApiService } from 'src/app/Modules/core/services/storage-location/storage-location-api.service';
import { StorageLocationView } from 'src/app/Modules/core/DataModels/storage-location.model';
import { DropDownListComponent } from '@syncfusion/ej2-angular-dropdowns';

@Component({
  selector: 'app-lot-movement-form',
  templateUrl: './lot-movement-form.component.html',
  styleUrls: ['./lot-movement-form.component.css']
})
export class LotMovementFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;

  public isUpdate: Boolean;
  public title: string;
  public lotMovementForm: FormGroup;
  public itemsList: ItemView[];
  public itemFields: { text: string, value: string };
  public storagesList: StorageLocationView[];
  public storageFields: { text: string, value: string };
  public lotsList: StockBatchListView[];
  public lotFields: { text: string, value: string };
  public lotStoragesList: StockBatchStorageView[];
  public lotStorageFields: { text: string, value: string };

  private lotId: number;

  constructor(private stockLotApi: StockBatchApiService,
    private itemApi: ItemApiService,
    private storageApi: StorageLocationApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location) {
    super();

    this.createForm();

    this.storageFields = { text: 'name', value: 'id' };
    this.itemFields = { text: 'name', value: 'id' };
    this.lotFields = { text: 'id', value: 'id' };
    this.lotStorageFields = { text: 'storage', value: 'id' };
  }

  ngOnInit() {
    this.lotId = + this.activatedRoute.snapshot.paramMap.get('lotId');
    this.title = this.activatedRoute.snapshot.data['title'];

    this.itemApi.getAllItems().subscribe(
      (data: ItemView[]) => this.itemsList = data,
      this.handleError
    );

    this.storageApi.getAllStorageLocations().subscribe(
      (data: StorageLocationView[]) => this.storagesList = data,
      this.handleError
    );

    this.stockLotApi.getAllStockBatchs().subscribe(
      (data: StockBatchListView[]) => this.lotsList = data,
      this.handleError
    );
    if (this.lotId) {
      this.currentLotId.setValue(this.lotId);

      this.stockLotApi.getStockBatchById(this.lotId).subscribe(
        (data: StockBatchDetailView) => {
          this.itemChanged(data.itemId);
          this.lotChanged(this.lotId);

        },
        this.handleError
      );
    }
  }

  private createForm(): void {
    this.lotMovementForm = this.formBuilder.group({
      itemId: ['', Validators.required],
      currentLotId: ['', Validators.required],
      currentStorage: ['', Validators.required],
      quantity: ['', Validators.required],
      newStorage: ['', Validators.required],
    });
  }

  itemChanged(selectedItemId: number): void {

    if (selectedItemId) {
      this.itemId.setValue(selectedItemId);
      this.stockLotApi.getItemStockBatchById(selectedItemId).subscribe(
        (data: any) => this.lotsList = data,
        this.handleError
      );
    }
  }

  lotChanged(selectedLotId: number): void {

    if (selectedLotId) {
      this.currentLotId.setValue(selectedLotId);
      this.stockLotApi.getStockLotStorages(selectedLotId).subscribe(
        (data: StockBatchStorageView[]) => this.lotStoragesList = data,
        this.handleError
      );
    }
  }



  get itemId(): FormControl {
    return this.lotMovementForm.get('itemId') as FormControl;
  }

  get currentStorage(): FormControl {
    return this.lotMovementForm.get('currentStorage') as FormControl;
  }

  get quantity(): FormControl {
    return this.lotMovementForm.get('quantity') as FormControl;
  }

  get currentLotId(): FormControl {
    return this.lotMovementForm.get('currentLotId') as FormControl;
  }

  get newStorage(): FormControl {
    return this.lotMovementForm.get('newStorage') as FormControl;
  }



  onSubmit(): void {
    const newMovement = this.prepareFormData();

    if (newMovement) {
      this.stockLotApi.moveStockLot(newMovement).subscribe(
        (data: StockBatchDetailView) => {
          this.notification.showMessage('Stock lot movement completed successfuly');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Error occured While moveing stock lot, try agin later');
          this.handleError(error);
        }
      );
    }
  }

  prepareFormData(): StockLotMovementModel | null {

    if (this.lotMovementForm.invalid) {
      return null;
    }

    const lotMovement = new StockLotMovementModel();

    lotMovement.lotId = this.currentStorage.value;
    lotMovement.quantity = this.quantity.value;
    lotMovement.newStorageId = this.newStorage.value;

    return lotMovement;
  }


}
