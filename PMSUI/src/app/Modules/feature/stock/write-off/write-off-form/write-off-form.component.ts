import { Component, OnInit, ViewChild } from '@angular/core';
import { WriteOffApiService } from '../write-off-api.service';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { WriteOffDetailModel, NewWriteOffModel, UpdatedWriteOffModel } from '../write-off-data.model';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { StockBatchListView } from 'src/app/Modules/core/DataModels/stock-batch.model';
import { StockBatchApiService } from 'src/app/Modules/core/services/stock-batch/stock-batch-api.service';

@Component({
  selector: 'app-write-off-form',
  templateUrl: './write-off-form.component.html',
  styleUrls: ['./write-off-form.component.css']
})
export class WriteOffFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;

  public writeOffTypes = ['Scrap', 'R&D'];
  public writeOffStatus = ['Valid', 'Canceled'];

  private writeoffId: number;
  public isAddNew: Boolean;
  public isUpdate: Boolean;
  public writeOffForm: FormGroup;
  public submitButtonText: string;
  public title: string;
  public itemsList: ItemView[];
  public writenOffItems: WriteOffDetailModel = null;
  public itemBatchList: StockBatchListView[] = [];
  public itemFields: { text: string, value: string };


  constructor(private formBuilder: FormBuilder,
    private writeoffApi: WriteOffApiService,
    private activatedRoute: ActivatedRoute,
    private itemsApi: ItemApiService,
    private stockBatchApi: StockBatchApiService,
    private location: Location) {
    super();

    this.itemFields = { text: 'name', value: 'id' };
    this.createForm();
  }

  ngOnInit() {
    this.writeoffId = + this.activatedRoute.snapshot.paramMap.get('writeoffId');
    this.title = this.activatedRoute.snapshot.data['title'];

    this.itemsApi.getAllItems().subscribe(
      (data: ItemView[]) => this.itemsList = data,
      this.handleError
    );

    this.submitButtonText = 'Create';
    this.isUpdate = false;
    if (this.writeoffId) {
      this.isUpdate = true;
      this.submitButtonText = 'Update';
      this.writeoffApi.getWriteOffById(this.writeoffId).subscribe(
        (data: WriteOffDetailModel) => this.initializeForm(data),
        this.handleError
      );

    }


  }

  deleteWriteOff() {
    if (this.isUpdate && this.writeoffId) {
      this.writeoffApi.deleteWriteOff(this.writeoffId).subscribe(
        () => {
          this.notification.showMessage('Write-off deleted Successfully!!!');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed while attempting to delete write-off, try again', 'error');
          this.handleError(error);
        }
      );
    }
  }

  private createForm(): void {
    this.writeOffForm = this.formBuilder.group({
      itemId: ['', Validators.required],
      note: [''],
      status: ['valid'],
      type: ['', Validators.required],
      writeoffBatchs: this.formBuilder.array([])
    });

    this.itemId.valueChanges.subscribe(
      (data) => {
        console.log(data);
        if (data != null) {
          this.stockBatchApi.getItemStockBatchById(data).subscribe(
            (batch: StockBatchListView[]) => this.resetBatchItems(batch)
          );

        }
      }
    );
  }

  private createWriteOffBatchArea(batch: StockBatchListView): FormGroup {
    return this.formBuilder.group({
      storageId: [batch.id, Validators.required],
      quantity: ['', [Validators.required]]
    });
  }

  private resetBatchItems(batchs: StockBatchListView[]): void {
    this.writeoffBatchs.controls = [];
    this.itemBatchList = batchs;
    if (batchs.length > 0) {
      batchs.map(b => this.writeoffBatchs.push(this.createWriteOffBatchArea(b)));
    }
  }

  private initializeForm(writeoff: WriteOffDetailModel): void {
    this.writenOffItems = writeoff;
    this.writeOffForm = this.formBuilder.group({
      itemId: [writeoff.itemId, Validators.required],
      note: [writeoff.note],
      type: [writeoff.type, Validators.required],
      status: [writeoff.status, Validators.required],
      writeoffBatchs: this.formBuilder.array([])
    });
  }

  get itemId(): FormControl {
    return this.writeOffForm.get('itemId') as FormControl;
  }

  get note(): FormControl {
    return this.writeOffForm.get('note') as FormControl;
  }

  get status(): FormControl {
    return this.writeOffForm.get('status') as FormControl;
  }

  get type(): FormControl {
    return this.writeOffForm.get('type') as FormControl;
  }

  get writeoffBatchs(): FormArray {
    return this.writeOffForm.get('writeoffBatchs') as FormArray;
  }



  batchItem(index: number): FormControl {
    return this.writeoffBatchs.controls[index].get('storageId') as FormControl;
  }

  quantity(index: number): FormControl {
    return this.writeoffBatchs.controls[index].get('quantity') as FormControl;
  }

  onSubmit(): void {



    if (!this.isUpdate) {
      const writeoff = this.prepareNewWriteoffModel();
      if (writeoff) {
        this.writeoffApi.createWriteOff(writeoff).subscribe(
          (data) => {
            this.isUpdate = true;
            this.title = 'Update';
            this.submitButtonText = 'Update';
            this.notification.showMessage('Item Written off Successfully');
            this.initializeForm(data);
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('fasiled while writing off stock try again!!!', 'error');
            this.handleError(error);
          }
        );
      }
    } else if (this.isUpdate) {
      const writeoff = this.prepareUpdatedWriteoffModel();
      if (writeoff) {
        this.writeoffApi.updateWriteOff(writeoff).subscribe(
          (data) => {
            this.notification.showMessage('Item Write-off Updated Successfully');
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Failed while updating Item Write-off, Try Again!!', 'error');
            this.handleError(error);
          }
        );
      }
    }

  }

  addWriteOff(): void {
    this.isAddNew = true;
    if (this.writenOffItems) {
      this.stockBatchApi.getItemStockBatchById(this.writenOffItems.itemId).subscribe(
        (batch: StockBatchListView[]) => this.resetBatchItems(batch)
      );
    }
  }

  updateWrittenOffItem(): void {

  }
  private prepareNewWriteoffModel(): NewWriteOffModel | null {
    const writeoff = new NewWriteOffModel();
    if (this.writeOffForm.valid) {

      writeoff.itemId = this.itemId.value;
      writeoff.note = this.note.value;
      writeoff.type = this.type.value;

      for (let i = 0; i < this.writeoffBatchs.controls.length; i++) {
        const quantity = this.quantity(i).value;
        if (quantity > 0) {
          writeoff.writeOffBatchs.push({
            quantity: quantity,
            batchStorageId: this.batchItem(i).value
          });
        }
      }

      return writeoff;
    } else {
      return null;
    }

  }

  private prepareUpdatedWriteoffModel(): UpdatedWriteOffModel | null {
    const writeoff = new UpdatedWriteOffModel();
    if (this.writeOffForm.valid) {
      writeoff.id = this.writeoffId;
      writeoff.note = this.note.value;
      writeoff.status = this.status.value;
      writeoff.type = this.type.value;

      for (let i = 0; i < this.writeoffBatchs.controls.length; i++) {
        const quantity = this.quantity(i).value;
        console.log(this.quantity(i).value);
        if (quantity > 0) {
          writeoff.writeOffBatchs.push({
            quantity: quantity,
            batchStorageId: this.batchItem(i).value
          });
        }
      }

      return writeoff;
    } else {
      return null;
    }

  }
}
