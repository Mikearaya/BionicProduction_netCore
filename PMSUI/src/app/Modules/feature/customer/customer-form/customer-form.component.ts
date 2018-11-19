import { Location } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';

import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService, Customer } from 'src/app/Modules/core/services/customers/customer.service';


@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  form: FormGroup;
  @Input('customer') customer: Customer;
  isUpdate: Boolean = false;
  customerId: number;
  private title: String = '';
  private customerSelfContained: Boolean = false;
  private redirected: String = 'false';
  errorMessages: any;
  @Input('isForeigner') isForeigner: Boolean;
  constructor(private formBuilder: FormBuilder,
    private customerService: CustomerService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private router: Router) {
    this.generateForm();


  }

  ngOnInit() {
    this.customerId = + this.activatedRoute.snapshot.paramMap.get('customerId');
    this.customerSelfContained = this.activatedRoute.snapshot.data['customerSelfContained'];
    this.title = this.activatedRoute.snapshot.data['title'];
    if (this.customerId) {
      this.isUpdate = true;
      this.customerService.getCustomerById(this.customerId)
        .subscribe((customer: Customer) => this.generateForm(customer),
          (error: any) => console.log(error)
        );
    }
  }

  get customerForm() { return this.form; }

  currentTask(): String {
    return this.title;
  }
  isSelfContained(): Boolean {
    return this.customerSelfContained;
  }
  private generateForm(currentCustomer: any | Customer = '') {
    this.customer = (currentCustomer) ? (<Customer>currentCustomer) : null;
    this.form = this.formBuilder.group({
      firstName: this.buildControl(currentCustomer.first_name, true),
      lastName: this.buildControl(currentCustomer.last_name, true),
      passportNumber: this.buildControl(currentCustomer.passport_number),
      drivingLicenceId: this.buildControl(currentCustomer.driving_licence_id, true),
      nationality: this.buildControl(currentCustomer.nationality),
      country: this.buildControl(currentCustomer.country, true),
      city: this.buildControl(currentCustomer.city, true),
      houseNo: this.buildControl(currentCustomer.house_no, true),
      mobileNumber: this.buildControl(currentCustomer.mobile_number, true),
      otherPhone: this.buildControl(currentCustomer.other_phone),
      hotelName: this.buildControl(currentCustomer.hotel_name),
      hotelPhone: this.buildControl(currentCustomer.hotel_phone),
    });
  }

  prepareDataModel(): Customer {
    const formModel = this.form.value;
    const dataModel: Customer = {
      CUSTOMER_ID: this.customerId,
      first_name: formModel.firstName,
      last_name: formModel.lastName,
      passport_number: (formModel.passportNumber) ? formModel.passportNumber : '',
      driving_licence_id: formModel.drivingLicenceId,
      hotel_phone: (formModel.hotelPhone) ? formModel.hotelPhone : '',
      hotel_name: (formModel.hotelName) ? formModel.hotelName.trim() : '',
      nationality: formModel.nationality,
      country: formModel.country,
      city: formModel.city,
      house_no: formModel.houseNo,
      mobile_number: formModel.mobileNumber,
      other_phone: (formModel.otherPhone.trim()) ? formModel.otherPhone : ''
    };
    return dataModel;
  }

  private buildControl(value = '', required = false) {
    return (required) ? [value, Validators.required] : value;
  }

  onSubmit() {
    this.customer = this.prepareDataModel();
    if (this.isUpdate) {
      this.customerService.updateCustomer(this.customer)
        .subscribe((success: Customer) => this.handelSuccess(success),
          (error: HttpErrorResponse) => this.handelError(error));
    } else {
      this.customerService.addCustomer(this.customer)
        .subscribe((success: Customer) => this.handelSuccess(success),
          (error: HttpErrorResponse) => this.handelError(error));
    }
  }

  handelSuccess(result: Customer) {
  }

  cancel() {
    this.location.back();
  }
  handelError(error: HttpErrorResponse) {
    this.errorMessages = error.error;
  }

}
