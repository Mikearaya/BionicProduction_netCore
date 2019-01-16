import { Component, OnInit, ViewChild } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { VendorViewModel, VendorModel } from 'src/app/Modules/core/DataModels/vendor-data.model';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { TabComponent } from '@syncfusion/ej2-angular-navigations';
import { VendorApiService } from 'src/app/Modules/core/services/vendor/vendor-api.service';


@Component({
  selector: 'app-vendor-form',
  templateUrl: './vendor-form.component.html',
  styleUrls: ['./vendor-form.component.css']
})
export class VendorFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  public notification: NotificationComponent;
  public isUpdate: Boolean;
  public errorMessages: any[];
  public created: Boolean;
  public vendorForm: FormGroup;
  public title: string;
  public submitButtonText: string;
  public fields: Object = { text: 'text', value: 'headerStyle' };
  public height: String = '220px';
  public value: String = 'default';

  public vendorId: number;
  @ViewChild('element') tabObj: TabComponent;

  @ViewChild('headerStyles') listObj: TabComponent;
  public headerText: Object[] = [
    { Id: 'header1', headerStyle: 'fill', text: 'General' },
    { Id: 'header2', headerStyle: 'fill', text: 'Purchase Terms' }
  ];


  constructor(private vendorApi: VendorApiService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) {
    super();
    this.createForm();
  }

  ngOnInit() {
    this.vendorId = + this.activatedRoute.snapshot.paramMap.get('vendorId');

    this.isUpdate = false;
    this.title = 'Create New Vendor';
    this.submitButtonText = 'Save';
    if (this.vendorId) {
      this.isUpdate = true;
      this.title = `Update Vendor #${this.vendorId}`;
      this.submitButtonText = 'Update';

      this.vendorApi.getVendorById(this.vendorId).subscribe(
        (data: VendorViewModel) => this.initializeForm(data),
        this.handleError
      );
    }

  }


  private createForm(): void {
    this.vendorForm = this.formBuilder.group({
      name: ['', Validators.required],
      phoneNumber: [''],
      tinNumber: [''],
      leadTime: [''],
      paymentPeriod: [''],
    });
  }

  private initializeForm(vendor: VendorViewModel): void {
    this.vendorForm = this.formBuilder.group({
      id: [vendor.id, Validators.required],
      name: [vendor.name, Validators.required],
      phoneNumber: [vendor.phoneNumber],
      tinNumber: [vendor.tinNumber],
      leadTime: [vendor.leadTime],
      paymentPeriod: [vendor.paymentPeriod],
    });
  }

  get vendorName(): FormControl {
    return this.vendorForm.get('name') as FormControl;
  }

  get phoneNumber(): FormControl {
    return this.vendorForm.get('phoneNumber') as FormControl;
  }


  get tinNumber(): FormControl {
    return this.vendorForm.get('tinNumber') as FormControl;
  }


  get leadTime(): FormControl {
    return this.vendorForm.get('leadTime') as FormControl;
  }


  get paymentPeriod(): FormControl {
    return this.vendorForm.get('paymentPeriod') as FormControl;
  }


  onSubmit(): void {
    const vendor = this.prepareFormData();

    if (vendor && this.isUpdate) {
      this.vendorApi.updateVendor(vendor).subscribe(
        () => this.notification.showMessage('Vendor Updated Successfuly'),
        (error: CustomErrorResponse) => {
          if (error.errorNumber === 422) {
            this.errorMessages = error.errorDetail;
          } else {
            this.handleError(error);
          }
        }
      );
    } else {
      this.vendorApi.createVendor(vendor).subscribe(
        (data: VendorViewModel) => {
          this.created = true;
          this.vendorId = data.id;
          this.notification.showMessage('Vendor Created Successfuly');
        },
        (error: CustomErrorResponse) => {
          if (error.errorNumber === 422) {
            this.created = false;
            this.errorMessages = error.errorDetail;
          } else {
            this.handleError(error);
          }
        }
      );
    }

  }

  private prepareFormData(): VendorModel | null {

    if (this.vendorForm.invalid) {
      return null;
    }

    const vendor = new VendorModel();
    if (this.isUpdate && this.vendorId) {
      vendor.id = this.vendorId;
    }

    vendor.name = this.vendorName.value;
    vendor.phoneNumber = this.phoneNumber.value;
    vendor.tinNumber = this.tinNumber.value;
    vendor.leadTime = this.leadTime.value;
    vendor.paymentPeriod = this.paymentPeriod.value;

    return vendor;

  }

}
