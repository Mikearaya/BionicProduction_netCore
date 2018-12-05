/*
 * @CreateTime: Dec 5, 2018 10:41 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 10:58 AM
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


@Component({
  selector: 'app-bom-form',
  templateUrl: './bom-form.component.html',
  styleUrls: ['./bom-form.component.css']
})
export class BomFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification')
  public notification: NotificationComponent;
  private bomId: number;
  private bomForm: FormGroup;
  public isUpdate: Boolean;
  public submitButtomText: string;
  public title: string;

  constructor(private bomApi: BomApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location) {
    super();
    this.createForm();
  }

  ngOnInit() {
    this.bomId = + this.activatedRoute.snapshot.paramMap.get('bomId');

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
      bomItems: this.formBuilder.array([])
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
        this.bomApi.updateBomItem(bom).subscribe(
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

    bomData.id = bom.id;
    bomData.name = bom.name;
    bomData.active = bom.active;

    bom.bomItems.forEach(element => {
      bomData.bomItems.push(element);
    });

    return bomData;

  }


}
