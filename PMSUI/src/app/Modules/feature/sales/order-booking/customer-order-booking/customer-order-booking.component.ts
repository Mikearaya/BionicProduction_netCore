import { Component, OnInit, ViewChild } from '@angular/core';
import { GridComponent, CommandModel, TextWrapSettingsModel, EditSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { bookingDetailColumnBluePrint } from './customer-order-booking-detail-blue-print';
import { ClickEventArgs } from '@syncfusion/ej2-splitbuttons';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { BookingApiService } from '../booking-api.service';
import { OrderBookingView } from '../order-booking-data';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-customer-order-booking',
  templateUrl: './customer-order-booking.component.html',
  styleUrls: ['./customer-order-booking.component.css']
})
export class CustomerOrderBookingComponent implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;
  public orderBookingForm: FormGroup;
  public data: OrderBookingView;

  private customerOrderId: number;
  public initialPage: Object;
  public columnBluePrint = bookingDetailColumnBluePrint;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public wrapSettings: TextWrapSettingsModel;
  public editSettings: EditSettingsModel;

  constructor(private bookingService: BookingApiService, private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location) {
    this.createForm();
  }

  ngOnInit() {


    this.customerOrderId = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');
    this.bookingService.getCustomerOrderBookings(this.customerOrderId)
      .subscribe((data: OrderBookingView) => {
        this.initializeForm(data);
        this.data = data;
      },
        (error: HttpErrorResponse) => console.log(error));

    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.wrapSettings = { wrapMode: 'Header' };
    this.commands = [
      { buttonOption: { content: 'Book Available', cssClass: 'e-success', click: this.bookAvailable.bind(this) } }
    ];
  }

  createForm(): void {
    this.orderBookingForm = this.formBuilder.group({
      createManufactureOrder: [false],
      products: this.formBuilder.array([])
    });
  }

  get products(): FormArray {
    return this.orderBookingForm.get('products') as FormArray;
  }

  initializeForm(data: OrderBookingView): void {

    data.orderItems.forEach(element => {
      this.products.push(this.formBuilder.group({
        orderItemId: [element.id, Validators.required],
        createManufactureOrder: [false, Validators.required]
      }));
    });
  }

  bookAvailable(args: Event): void {
    const arr = this.products.controls[0];
    console.log(arr);
  }

  toolbarClick(args: ClickEventArgs): void {

  }

  back(): void {
    this.location.back();
  }

  onSubmit(): void {
    const arr = this.products.controls;
    console.log(arr);
  }


}
