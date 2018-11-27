import { Location } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';

import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray, } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from 'src/app/Modules/core/services/customers/customer.service';
import { Customer } from 'src/app/Modules/core/DataModels/customer-data.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';


@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification')
  private notification: NotificationComponent;
  public customerTypes = ['Individual', 'Business'];
  public phoneTypes = ['Office', 'Mobile'];
  public socialMediaList = ['Facebook', 'Twitter', 'LinkedIn', 'Instagram', 'Skype'];
  public countriesList = ['Ethiopia', 'Kenya', 'Sudan'];

  customerForm: FormGroup;
  isUpdate: Boolean = false;
  customerId: number;
  private customer: Customer;
  private title: String = '';
  private customerSelfContained: Boolean = false;
  private redirected: String = 'false';
  errorMessages: any;
  constructor(private formBuilder: FormBuilder,
    private customerService: CustomerService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private router: Router) {
    super();
    this.generateForm();


  }

  ngOnInit() {
    this.customerId = + this.activatedRoute.snapshot.paramMap.get('customerId');
    this.customerSelfContained = this.activatedRoute.snapshot.data['customerSelfContained'];
    this.title = this.activatedRoute.snapshot.data['title'];
    if (this.customerId) {
      this.isUpdate = true;
      this.customerService.getCustomerById(this.customerId).subscribe((customer: Customer) =>
        this.generateForm(customer),
        this.handleError
      );
    }
  }

  private generateForm(currentCustomer: any | Customer = '') {
    this.customer = (currentCustomer) ? (<Customer>currentCustomer) : null;
    this.customerForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      type: ['', Validators.required],
      tinNo: [''],
      email: ['', [Validators.email]],
      taxRate: [''],
      paymentPeriod: [''],
      creditLimit: [''],
      fax: [''],
      poBox: [''],
      telephones: this.formBuilder.array([]),
      socialMedias: this.formBuilder.array([]),
      addresses: this.formBuilder.array([])

    });
  }
  get fullName(): FormControl {
    return this.customerForm.get('fullName') as FormControl;
  }


  get email(): FormControl {
    return this.customerForm.get('email') as FormControl;
  }

  get type(): FormControl {
    return this.customerForm.get('type') as FormControl;
  }

  get tinNo(): FormControl {
    return this.customerForm.get('fullName') as FormControl;
  }
  get taxRate(): FormControl {
    return this.customerForm.get('taxRate') as FormControl;
  }

  get paymentPeriod(): FormControl {
    return this.customerForm.get('paymentPeriod') as FormControl;
  }
  get creditLimit(): FormControl {
    return this.customerForm.get('creditLimit') as FormControl;
  }

  get fax(): FormControl {
    return this.customerForm.get('fax') as FormControl;
  }

  get poBox(): FormControl {
    return this.customerForm.get('poBox') as FormControl;
  }

  get telephones(): FormArray {
    return this.customerForm.get('telephones') as FormArray;
  }

  get addresses(): FormArray {
    return this.customerForm.get('addresses') as FormArray;
  }

  get socialMedias(): FormArray {
    return this.customerForm.get('socialMedias') as FormArray;
  }


  private createTelephoneRecord(): FormGroup {
    return this.formBuilder.group({
      type: ['', Validators.required],
      number: ['', [Validators.min(10)]], // TODO: create pattern for telephone
    });
  }

  private createSocialMedia(): FormGroup {
    return this.formBuilder.group({
      address: ['', Validators.required],
      site: ['', Validators.required],
    });
  }

  private createAddress(): FormGroup {
    return this.formBuilder.group({
      location: ['', Validators.required],
      city: ['', Validators.required],
      subCity: ['', Validators.required],
      country: ['', Validators.required],
      phoneNumber: ['', [Validators.min(10), Validators.max(12)]],
    });
  }

  addPhone(): void {
    this.telephones.push(this.createTelephoneRecord());
  }

  deletePhone(index: number): void {
    this.telephones.removeAt(index);
  }

  addSocialAddress(): void {
    this.socialMedias.push(this.createSocialMedia());
  }

  deleteSocialAddress(index: number): void {
    this.socialMedias.removeAt(index);
  }

  prepareDataModel(): Customer {
    const formModel = this.customerForm.value;
    const dataModel: Customer = {
      CUSTOMER_ID: this.customerId,
      fullName: formModel.fullName,
      type: formModel.type,
      fax: formModel.fax,
      poBox: formModel.poBox,
      creditLimit: formModel.creditLimit,
      paymentPeriod: formModel.paymentPeriod,
      email: formModel.email,
      addresses: [],
      telephones: [],
      socialMedias: []
    };

    this.addresses.controls.forEach(element => {
      dataModel.addresses.push({
        city: element.value.city,
        country: element.value.country,
        subCity: element.value.subCity,
        location: element.value.location
      });
    });

    this.socialMedias.controls.forEach(element => {
      dataModel.socialMedias.push({
        site: element.value.site,
        address: element.value.address
      });
    });

    this.telephones.controls.forEach(element => {
      dataModel.telephones.push({
        type: element.value.type,
        number: element.value.number
      });
    });
    console.log(dataModel);
    return dataModel;
  }

  onSubmit() {
    this.customer = this.prepareDataModel();
    console.log(`${this.customer}`);
    if (this.isUpdate) {
      this.customerService.updateCustomer(this.customer).subscribe(
        () => {
          this.notification.showMessage('Customer Record Updated Successfuly', 'success');
          this.location.back();
        },
        this.handleError
      );
    } else {
      this.customerService.addCustomer(this.customer).subscribe(
        () => {
          this.notification.showMessage('Customer Created Successfuly', 'success');
          this.location.back();
        },
        this.handleError
      );
    }
  }


  addAddress(): void {
    this.addresses.push(this.createAddress());
  }

  removeAddress(index: number): void {
    this.addresses.removeAt(index);
  }



}
