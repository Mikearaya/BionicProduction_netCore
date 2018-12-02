import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ItemModel, ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { ItemApiService } from '../stock-api.service';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { Location } from '@angular/common';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';



@Component({
  selector: 'app-stock-form',
  templateUrl: './stock-form.component.html',
  styleUrls: ['./stock-form.component.css']
})
export class StockFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;
  public itemGroups = [1];
  public unitOfMesurmentList = [1];

  public submitButtonText: string;
  public title: string;
  public productForm: FormGroup;
  public isUpdate: Boolean = false;
  private itemId: number;
  public submitted: Boolean = false;

  constructor(private itemApi: ItemApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location) {
    super();
    this.createForm();
  }

  ngOnInit() {
    this.itemId = + this.activatedRoute.snapshot.paramMap.get('itemId');

    if (this.itemId) {

      this.title = 'Create New Item';
      this.submitButtonText = 'Update';
      this.isUpdate = true;
      this.itemApi.getItemById(this.itemId).subscribe(
        (data: ItemView) => this.initializeForm(data),
        this.handleError
      );
    } else {
      this.title = 'Update Item';
      this.submitButtonText = 'Create';
    }
  }

  get code(): FormControl {
    return this.productForm.get('code') as FormControl;
  }
  get name(): FormControl {
    return this.productForm.get('name') as FormControl;
  }
  get groupId(): FormControl {
    return this.productForm.get('groupId') as FormControl;
  }

  get storingUomId(): FormControl {
    return this.productForm.get('storingUomId') as FormControl;
  }

  get manufacturingUomId(): FormControl {
    return this.productForm.get('manufacturingUomId') as FormControl;
  }

  get minimumQuantity(): FormControl {
    return this.productForm.get('minimumQuantity') as FormControl;
  }

  get isProcured(): FormControl {
    return this.productForm.get('isProcured') as FormControl;
  }

  get isInventoryItem(): FormControl {
    return this.productForm.get('isInventoryItem') as FormControl;
  }

  get weight(): FormControl {
    return this.productForm.get('weight') as FormControl;
  }

  get shelfLife(): FormControl {
    return this.productForm.get('shelfLife') as FormControl;
  }

  get price(): FormControl {
    return this.productForm.get('price') as FormControl;
  }
  get image(): FormControl {
    return this.productForm.get('image') as FormControl;
  }
  get unitCost(): FormControl {
    return this.productForm.get('unitCost') as FormControl;
  }

  createForm(): void {
    this.productForm = this.formBuilder.group({
      code: ['', Validators.required],
      name: ['', Validators.required],
      groupId: ['', Validators.required],
      storingUomId: ['', Validators.required],
      manufacturingUomId: ['', Validators.required],
      minimumQuantity: [0, Validators.min(0)],
      isProcured: [false],
      isInventoryItem: [true],
      weight: ['', [Validators.required, Validators.min(0)]],
      shelfLife: [0, [Validators.required, Validators.min(0)]],
      price: ['', [Validators.required, Validators.min(0)]],
      image: [''],
      unitCost: ['', [Validators.required, Validators.min(0)]],
    });
  }


  initializeForm(item: ItemView) {
    this.productForm = this.formBuilder.group({
      code: [item.code, Validators.required],
      name: [item.name, Validators.required],
      groupId: [item.groupId, Validators.required],
      storingUomId: [item.storingUomId, Validators.required],
      unitCost: [item.unitCost, [Validators.required, Validators.min(0)]],
      manufacturingUomId: [item.manufacturingUomId, Validators.required],
      minimumQuantity: [item.minimumQuantity, Validators.min(0)],
      isProcured: [(item.isProcured) ? true : false],
      weight: [item.weight, [Validators.required, Validators.min(0)]],
      isInventoryItem: [(item.isInventoryItem) ? true : false],
      shelfLife: [item.shelfLife, [Validators.required, Validators.min(0)]],
      price: [item.price, [Validators.required, Validators.min(0)]],
      image: [item.photo]
    });

  }

  onSubmit() {

    const formData = this.prepareFormData(this.productForm.value);

    if (this.isUpdate === false) {
      this.itemApi.saveItem(formData).subscribe(
        (data: ItemModel) => {
          this.notification.showMessage('Item Created!!!');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Item Creation Failed', 'error');
          this.handleError(error);
        }
      );
    } else {
      this.itemApi.updateItem(formData).subscribe(
        () => {
          this.notification.showMessage('Item Updated!!!');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed while Updateing Item Failed', 'error');
          this.handleError(error);
        }
      );
    }

  }

  prepareFormData(form: any): ItemModel {
    return {
      id: this.itemId,
      code: form.code,
      description: form.description,
      name: form.name,
      groupId: form.groupId,
      stockUomId: form.storingUomId,
      manufacturingUomId: form.manufacturingUomId,
      isProcured: form.isProcured,
      isInventoryItem: form.isInventoryItem,
      minimumQuantity: form.minimumQuantity,
      weight: form.weight,
      price: form.price,
      shelfLife: form.shelfLife,
      unitCost: form.unitCost,
      image: form.image

    };
  }

}
