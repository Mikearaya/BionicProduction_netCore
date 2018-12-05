/*
 * @CreateTime: Dec 5, 2018 10:41 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 11:51 PM
 * @Description: Modify Here, Please
 */

import { ActivatedRoute } from '@angular/router';
import { Bom, BomItemView, BomView } from 'src/app/Modules/core/DataModels/bom.model';
import { BomApiService } from '../bom-api.service';
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
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { ProductsAPIService, Product } from 'src/app/Modules/core/services/items/products-api.service';
import { UnitOfMeasurmentApiService } from 'src/app/Modules/core/services/unit-of-measurment/unit-of-measurment-api.service';
import { UnitOfMeasurmentView } from 'src/app/Modules/core/DataModels/unit-of-measurment.mode';


@Component({
  selector: 'app-bom-form',
  templateUrl: './bom-form.component.html',
  styleUrls: ['./bom-form.component.css']
})
export class BomFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification')
  public notification: NotificationComponent;
  private bomId: number;
  public bomForm: FormGroup;
  public isUpdate: Boolean;
  public itemsList: Product[];
  public uomsList: UnitOfMeasurmentView[];
  public itemFields: { text: string, value: string };
  public uomFields: { text: string, value: string };

  public submitButtomText: string;
  public title: string;

  constructor(private bomApi: BomApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private productsApi: ProductsAPIService,
    private unitOfMeasureApi: UnitOfMeasurmentApiService,
    private location: Location) {
    super();
    this.createForm();

    this.uomFields = { text: 'abbrevation', value: 'id' };
    this.itemFields = { text: 'name', value: 'id' };
  }

  ngOnInit() {
    this.bomId = + this.activatedRoute.snapshot.paramMap.get('bomId');

    this.productsApi.getAllProducts().subscribe(
      (data: any) => this.itemsList = data.Items,
      this.handleError
    );

    this.unitOfMeasureApi.getAllUnitOfMeasures().subscribe(
      (data: UnitOfMeasurmentView[]) => this.uomsList = data,
      this.handleError
    );

    if (this.bomId) {

      this.isUpdate = true;
      this.submitButtomText = 'Update';
      this.title = 'Update BOM';

      this.bomApi.getBomItemById(this.bomId).subscribe(
        (data: BomView) => this.initializeForm(data)
      );
    } else {
      this.isUpdate = false;
      this.submitButtomText = 'Save';
      this.title = 'Create New BOM';
    }

  }


  private createForm(): void {
    this.bomForm = this.formBuilder.group({
      name: ['', Validators.required],
      itemId: ['', Validators.required],
      isActive: [true],
      bomItems: this.formBuilder.array([this.createBomItem()])
    });

  }

  private createBomItem(): FormGroup {
    return this.formBuilder.group({
      id: [''],
      itemId: ['', Validators.required],
      quantity: ['', [Validators.required, Validators.min(0)]],
      uomId: ['', Validators.required],
      note: ['']
    });
  }

  addBomItem(): void {
    this.bomItems.push(this.createBomItem());
  }

  removeBomItem(index: number): void {
    this.bomItems.removeAt(index);
  }

  get itemId(): FormControl {
    return this.bomForm.get('itemId') as FormControl;
  }

  get quantity(): FormControl {
    return this.bomForm.get('quantity') as FormControl;

  }

  get name(): FormControl {
    return this.bomForm.get('name') as FormControl;
  }

  get isActive(): FormControl {
    return this.bomForm.get('isActive') as FormControl;

  }


  private initializeBomItems(item: BomItemView): FormGroup {
    return this.formBuilder.group({
      id: [item.id, Validators.required],
      itemId: [item.itemId, Validators.required],
      quantity: [item.quantity, Validators.required],
      uomId: [item.uomId, Validators.required],
      note: [item.note]
    });
  }

  private initializeForm(bom: BomView): void {
    this.bomForm = this.formBuilder.group({
      id: [bom.id, Validators.required],
      name: [bom.name, Validators.required],
      itemId: [bom.itemId, Validators.required],
      isActive: [bom.active, Validators.required],
      bomItems: this.formBuilder.array([])
    });


    bom.bomItems.forEach(element => {
      this.bomItems.push(this.initializeBomItems(element));
    });
  }


  get bomItems(): FormArray {
    return this.bomForm.get('bomItems') as FormArray;
  }


  onSubmit(): void {
    if (this.bomForm.valid) {
      const bom = this.prepareFormData(this.bomForm.value);
      if (this.isUpdate) {
        this.bomApi.updateBomItem(bom).subscribe(
          () => {
            this.notification.showMessage('Bom Updated Successfuly');
            this.location.back();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Bom Could not be updated succesuly', 'error');
            this.handleError(error);
          }
        );
      } else {
        this.bomApi.saveBomItem(bom).subscribe(
          () => {
            this.notification.showMessage('Bom Item Created Successfuly');
            this.location.back();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Bom Item could not be update', 'error');
            this.handleError(error);
          }
        );
      }
    }
  }

  prepareFormData(bom: Bom): Bom {

    const bomData = new Bom();

    bomData.id = (bom.id) ? bom.id : 0;
    bomData.name = bom.name;
    bomData.active = bom.active;
    bomData.itemId = bom.itemId;

    bom.bomItems.forEach(element => {
      bomData.bomItems.push(element);
    });

    return bomData;

  }


}
