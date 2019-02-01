import { Component, OnInit, ViewChild } from '@angular/core';
import { UnitOfMeasurmentApiService } from 'src/app/Modules/core/services/unit-of-measurment/unit-of-measurment-api.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { UnitOfMeasurmentView, UnitOfMeasure } from 'src/app/Modules/core/DataModels/unit-of-measurment.mode';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-unit-of-measurment-form',
  templateUrl: './unit-of-measurment-form.component.html',
  styleUrls: ['./unit-of-measurment-form.component.css']
})
export class UnitOfMeasurmentFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;


  private uomId: number;
  public submitButtonText: string;
  public title: string;
  public isUpdate: Boolean;

  public uomForm: FormGroup;
  constructor(private unitOfMeasureApi: UnitOfMeasurmentApiService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private formBuilder: FormBuilder) {
    super();
    this.createForm();
  }

  ngOnInit() {
    this.uomId = + this.activatedRoute.snapshot.paramMap.get('uomId');

    if (this.uomId) {
      this.isUpdate = true;
      this.submitButtonText = 'Update';
      this.title = 'Update Unit of Measure';

      this.unitOfMeasureApi.getAllUnitOfMeasureById(this.uomId).subscribe(
        (data: UnitOfMeasurmentView) => this.initializaForm(data),
        this.handleError
      );

    } else {
      this.isUpdate = false;
      this.submitButtonText = 'Save';
      this.title = 'Create Unit of Measure';
    }
  }

  private createForm(): void {
    this.uomForm = this.formBuilder.group({
      name: ['', Validators.required],
      abbrevation: ['', Validators.required],
      isActive: [true, Validators.required]
    });
  }

  get name(): FormControl {
    return this.uomForm.get('name') as FormControl;
  }

  get abbrevation(): FormControl {
    return this.uomForm.get('abbrevation') as FormControl;
  }


  get isActive(): FormControl {
    return this.uomForm.get('isActive') as FormControl;
  }

  private initializaForm(uom: UnitOfMeasurmentView): void {

    this.uomForm = this.formBuilder.group({
      name: [uom.name, Validators.required],
      abbrevation: [uom.abbrevation, Validators.required],
      isActive: [uom.active, Validators.required]
    });
  }


  onSubmit(): void {
    if (this.uomForm.valid) {
      const uom = this.prepareFormData(this.uomForm.value);

      if (!this.isUpdate) {
        this.unitOfMeasureApi.saveUnitOfMeasurment(uom).subscribe(
          () => {
            this.notification.showMessage('Unit of Measurement Created!!!');
            this.location.back();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Faild to create Unit of Measurement!!!', 'error');
            this.handleError(error);
          }
        );
      } else {
        this.unitOfMeasureApi.updateUnitOfMeasurment(uom).subscribe(
          () => {
            this.notification.showMessage('Unit of Measurement Updated!!!');
            this.location.back();
          },
          (error: CustomErrorResponse) => {
            this.notification.showMessage('Faild to Update Unit of Measurement!!!', 'error');
            this.handleError(error);
          }
        );
      }
    }
  }

  deleteUnitOfMeasure(): void {
    if (this.isUpdate && this.uomId) {
      this.unitOfMeasureApi.deleteUnitOfMeasurment(this.uomId).subscribe(
        () => {
          this.notification.showMessage('Unit of measure deleted successfuly!');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed while attempting to delete unit of measurment, try again later', 'error');
          this.handleError(error);
        }
      );
    }
  }

  private prepareFormData(formData: any): UnitOfMeasure {

    return {
      id: (this.uomId) ? this.uomId : 0,
      Name: formData.name,
      Abrivation: formData.abbrevation,
      Active: formData.isActive
    };

  }

}
