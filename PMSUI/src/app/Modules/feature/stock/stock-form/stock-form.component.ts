/*
 * @CreateTime: Dec 3, 2018 7:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 7, 2018 11:24 PM
 * @Description: Modify Here, Please
 */

import { ActivatedRoute, Router } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { ItemModel, ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { Location } from '@angular/common';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { ProductGroupView } from 'src/app/Modules/core/DataModels/product-group.model';
import { UnitOfMeasurmentApiService } from 'src/app/Modules/core/services/unit-of-measurment/unit-of-measurment-api.service';
import { UnitOfMeasurmentView } from 'src/app/Modules/core/DataModels/unit-of-measurment.mode';
import { TabComponent } from '@syncfusion/ej2-angular-navigations';
import { StorageLocationApiService } from 'src/app/Modules/core/services/storage-location/storage-location-api.service';
import { StorageLocationView } from 'src/app/Modules/core/DataModels/storage-location.model';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { ProductGroupApiService } from 'src/app/Modules/core/services/product-group/product-group-api.service';




@Component({
  selector: 'app-stock-form',
  templateUrl: './stock-form.component.html',
  styleUrls: ['./stock-form.component.css']
})
export class StockFormComponent extends CommonProperties implements OnInit {

  @ViewChild('procured')
  public procured: any;
  @ViewChild('notification')
  public notification: NotificationComponent;
  public itemGroups: ProductGroupView[];
  public unitOfMesurmentList: UnitOfMeasurmentView[];
  public storagesList: StorageLocationView[];
  @ViewChild('element') tabObj: TabComponent;

  @ViewChild('headerStyles') listObj: TabComponent;
  public headerText: Object[] = [
    { Id: 'header1', headerStyle: 'fill', text: 'General' },
    { Id: 'header2', headerStyle: 'fill', text: 'BOMs' },
    { Id: 'header3', headerStyle: 'fill', text: 'Routings' },
    { Id: 'header4', headerStyle: 'fill', text: 'Purchase Term' },
    { Id: 'header5', headerStyle: 'fill', text: 'General' }
  ];

  public submited: Boolean;
  public created: Boolean;

  public fields: Object = { text: 'text', value: 'headerStyle' };
  public height: String = '220px';
  public value: String = 'default';

  public submitButtonText: string;
  public title: string;
  public productForm: FormGroup;
  public isUpdate: Boolean = false;
  public itemId: number;
  public submitted: Boolean = false;
  public itemGroupFields: { text: string, value: string };
  public unitOfMeasureFields: { text: string; value: string; };
  public storageFields: { text: string; value: string; };

  constructor(private itemApi: ItemApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private productGroupApi: ProductGroupApiService,
    private unitOfMeasurmentApi: UnitOfMeasurmentApiService,
    private location: Location,
    private storageApi: StorageLocationApiService) {
    super();
    this.createForm();
    this.itemGroupFields = { text: 'groupName', value: 'id' };
    this.unitOfMeasureFields = { text: 'name', value: 'id' };
    this.storageFields = { text: 'name', value: 'id' };
  }

  ngOnInit() {
    this.itemId = + this.activatedRoute.snapshot.paramMap.get('itemId');

    this.productGroupApi.getAllProductGroups().subscribe(
      (data: ProductGroupView[]) => this.itemGroups = data,
      () => this.handleError
    );

    this.unitOfMeasurmentApi.getAllUnitOfMeasures().subscribe(
      (data: UnitOfMeasurmentView[]) => this.unitOfMesurmentList = data,
      this.handleError
    );

    this.storageApi.getAllStorageLocations().subscribe(
      (data: StorageLocationView[]) => this.storagesList = data,
      this.handleError
    );

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

  get primaryUomId(): FormControl {
    return this.productForm.get('primaryUomId') as FormControl;
  }


  get minimumQuantity(): FormControl {
    return this.productForm.get('minimumQuantity') as FormControl;
  }

  get storageId(): FormControl {
    return this.productForm.get('storageId') as FormControl;
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
      storageId: ['', Validators.required],
      primaryUomId: ['', Validators.required],
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
      primaryUomId: [item.primaryUomId, Validators.required],
      unitCost: [item.unitCost, [Validators.required, Validators.min(0)]],
      minimumQuantity: [item.minimumQuantity, Validators.min(0)],
      isProcured: [(item.isProcured) ? true : false],
      storageId: [item.defaultStorageId, Validators.required],
      weight: [item.weight, [Validators.required, Validators.min(0)]],
      isInventoryItem: [(item.isInventoryItem) ? true : false],
      shelfLife: [item.shelfLife, [Validators.required, Validators.min(0)]],
      price: [item.price, [Validators.required, Validators.min(0)]],
      image: [item.photo]
    });

  }

  onSubmit() {

    const formData = this.prepareFormData(this.productForm.value);
    this.submited = true;
    if (this.isUpdate === false) {
      this.itemApi.saveItem(formData).subscribe(
        (data: ItemModel) => {
          this.notification.showMessage('Item Created!!!');
          this.itemId = data.id;
          this.submited = true;
          this.created = true;
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Item Creation Failed', 'error');
          this.handleError(error);
          this.created = false;
          this.submited = false;
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
      primaryUomId: form.primaryUomId,
      isProcured: form.isProcured,
      isInventoryItem: form.isInventoryItem,
      minimumQuantity: form.minimumQuantity,
      defaultStorageId: form.storageId,
      weight: form.weight,
      price: form.price,
      shelfLife: form.shelfLife,
      unitCost: form.unitCost,
      image: form.image

    };
  }

}
