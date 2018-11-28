import { Location } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';

import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray, } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from 'src/app/Modules/core/services/customers/customer.service';
import { Customer, TelephoneAddress, Address, SocialMediaAddress } from 'src/app/Modules/core/DataModels/customer-data.model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CustomErrorResponse } from 'src/app/Modules/core/DataModels/system-data-models';


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

  errorMessages: any;
  errors: any;
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
    if (this.customerId) {
      this.isUpdate = true;
      this.customerService.getCustomerById(this.customerId).subscribe(
        (customer: Customer) => this.initializeForm(customer),
        this.handleError
      );
    }
  }

  private generateForm() {

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
      id: [0],
      type: ['', Validators.required],
      number: ['', [Validators.min(10)]], // TODO: create pattern for telephone
    });
  }

  private createSocialMedia(): FormGroup {
    return this.formBuilder.group({
      id: [0],
      address: ['', Validators.required],
      site: ['', Validators.required],
    });
  }

  private createAddress(): FormGroup {
    return this.formBuilder.group({
      id: [0],
      location: ['', Validators.required],
      city: ['', Validators.required],
      subCity: ['', Validators.required],
      country: ['', Validators.required],
      phoneNumber: ['', [Validators.min(10), Validators.max(12)]],
    });
  }

  private initializeForm(customer: Customer): void {

    this.customerForm = this.formBuilder.group({
      id: [customer.id, Validators.required],
      fullName: [customer.fullName, Validators.required],
      type: [customer.type, Validators.required],
      tinNo: [customer.tin],
      email: [customer.email, [Validators.email]],
      paymentPeriod: [customer.paymentPeriod],
      creditLimit: [customer.creditLimit],
      fax: [customer.fax],
      poBox: [customer.poBox],
      telephones: this.formBuilder.array([]),
      socialMedias: this.formBuilder.array([]),
      addresses: this.formBuilder.array([])

    });

    customer.telephones.forEach(element => {
      this.telephones.push(this.initializeTelephone(element));
    });
    customer.addresses.forEach(element => {
      this.addresses.push(this.InitializeAddress(element));
    });
    customer.socialMedias.forEach(element => {
      this.socialMedias.push(this.initializeSocialMedia(element));
    });

  }

  private initializeTelephone(telNo: TelephoneAddress): FormGroup {
    return this.formBuilder.group({
      id: [telNo.id, Validators.required],
      type: [telNo.type, Validators.required],
      number: [telNo.number, Validators.required]
    });
  }

  private InitializeAddress(address: Address): FormGroup {
    return this.formBuilder.group({
      id: [address.id, Validators.required],
      location: [address.location, Validators.required],
      city: [address.city, Validators.required],
      subCity: [address.subCity, Validators.required],
      country: [address.country, Validators.required],
    });
  }

  private initializeSocialMedia(media: SocialMediaAddress): FormGroup {
    return this.formBuilder.group({
      id: [media.id, Validators.required],
      address: [media.address, Validators.required],
      site: [media.site, Validators.required],
    });
  }

  addPhone(): void {
    this.telephones.push(this.createTelephoneRecord());
  }

  deletePhone(index: number): void {
    if ((this.telephones.controls[index].value).id !== 0) {
      this.customerService.deleteCustomerPhone(this.customerId, (this.telephones.controls[index].value).id).subscribe(
        () => this.notification.showMessage('Phone Number Deleted'),
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed deleting Phone Number', 'error');
          this.handleError(error);
        },
        () => this.telephones.removeAt(index)
      );
    } else {
      this.telephones.removeAt(index);
    }

  }

  addSocialAddress(): void {
    this.socialMedias.push(this.createSocialMedia());
  }

  deleteSocialAddress(index: number): void {
    if ((this.socialMedias.controls[index].value).id !== 0) {
      this.customerService.deleteCustomerSocialMediaAddress(this.customerId, (this.socialMedias.controls[index].value).id).subscribe(
        () => this.notification.showMessage('Social Media Account Deleted'),
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed deleting Social Media Account', 'error');
          this.handleError(error);
        },
        () => this.socialMedias.removeAt(index)
      );
    } else {
      this.socialMedias.removeAt(index);
    }
  }

  prepareDataModel(): Customer {
    const formModel = this.customerForm.value;
    const dataModel: Customer = {
      id: this.customerId,
      fullName: formModel.fullName,
      type: formModel.type,
      fax: formModel.fax,
      tin: formModel.tinNo,
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
        id: element.value.id,
        city: element.value.city,
        country: element.value.country,
        subCity: element.value.subCity,
        location: element.value.location
      });
    });

    this.socialMedias.controls.forEach(element => {
      dataModel.socialMedias.push({
        id: element.value.id,
        site: element.value.site,
        address: element.value.address
      });
    });

    this.telephones.controls.forEach(element => {
      dataModel.telephones.push({
        id: element.value.id,
        type: element.value.type,
        number: element.value.number
      });
    });

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
        (error: CustomErrorResponse) => {
          this.errors = (error.errorNumber === 422) ?
            this.notification.showMessage('Failed updating customer duplicate data exists', 'error') : [];
          this.handleError(error);
        }
      );
    } else {
      this.customerService.addCustomer(this.customer).subscribe(
        () => {
          this.notification.showMessage('Customer Created Successfuly', 'success');
          this.location.back();
        },
        (error: CustomErrorResponse) => {
          this.errors = (error.errorNumber === 422) ? error.errorDetail : [];
          this.notification.showMessage('Failed to Create Customer', 'error');
          this.handleError(error);
        }
      );
    }
  }


  addAddress(): void {
    this.addresses.push(this.createAddress());
  }

  removeAddress(index: number): void {
    if ((this.addresses.controls[index].value).id !== 0) {
      this.customerService.deleteCustomerAddress(this.customerId, (this.addresses.controls[index].value).id).subscribe(
        () => this.notification.showMessage('Address Deleted'),
        (error: CustomErrorResponse) => {
          this.notification.showMessage('Failed deleting Address', 'error');
          this.handleError(error);
        },
        () => this.addresses.removeAt(index)
      );

    } else {
      this.addresses.removeAt(index);
    }

  }



}
