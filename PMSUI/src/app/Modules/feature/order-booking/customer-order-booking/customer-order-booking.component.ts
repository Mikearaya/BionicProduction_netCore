import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { GridComponent, CommandModel, TextWrapSettingsModel, EditSettingsModel, ToolbarItems } from '@syncfusion/ej2-angular-grids';
import { bookingDetailColumnBluePrint } from './customer-order-booking-detail-blue-print';
import { ClickEventArgs } from '@syncfusion/ej2-splitbuttons';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { BookingApiService } from '../booking-api.service';
import { OrderBookingView, BookingModel } from '../order-booking-data';
import { HttpErrorResponse } from '@angular/common/http';
import { DataManager, WebApiAdaptor, Query, ReturnOption } from '@syncfusion/ej2-data';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-customer-order-booking',
  templateUrl: './customer-order-booking.component.html',
  styleUrls: ['./customer-order-booking.component.css']
})
export class CustomerOrderBookingComponent extends CommonProperties implements OnInit {
  @ViewChild('grid')
  public grid: GridComponent;
  @ViewChild('notification')
  private notification: NotificationComponent;
  public orderBookingForm: FormGroup;
  public data: OrderBookingView;
  public errors: Object[] = [];

  private customerOrderId: number;
  public initialPage: Object;
  public columnBluePrint = bookingDetailColumnBluePrint;
  public toolbar: ToolbarItems[];
  public commands: CommandModel[];
  public wrapSettings: TextWrapSettingsModel;
  public editSettings: EditSettingsModel;
  public employeesList: Object[];
  public employeeQuery: Query;
  public employeeFields: { text: string; value: string; };

  constructor(
    private bookingService: BookingApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    @Inject('BASE_URL') private apiUrl: string) {
    super();

    this.createForm();

    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.wrapSettings = { wrapMode: 'Header' };
    this.commands = [
      { buttonOption: { content: 'Book Available', cssClass: 'e-success', click: this.bookAvailable.bind(this) } }
    ];

    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
  }

  ngOnInit() {


    this.customerOrderId = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');
    this.bookingService.getCustomerOrderBookings(this.customerOrderId)
      .subscribe(
        (data: OrderBookingView) => {
          this.initializeForm(data);
          this.data = data;
        },
        (error: HttpErrorResponse) => console.log(error));


    const dm: DataManager = new DataManager(
      { url: `${this.apiUrl}/employees`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );


    dm.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);

  }

  createForm(): void {
    this.orderBookingForm = this.formBuilder.group({
      createManufactureOrder: [false],
      items: this.formBuilder.array([]),
      workStartDate: '',
      workEndDate: '',
      BookedBy: 11
    });
  }

  get products(): FormArray {
    return this.orderBookingForm.get('items') as FormArray;
  }

  initializeForm(data: OrderBookingView): void {

    data.orderItems.forEach(element => {
      this.products.push(this.formBuilder.group({
        CustomerOrderItemId: [element.id, Validators.required],
        Quantity: [element.remainingAmount],
        CreateManufactureOrder: [false, Validators.required],
      }));
    });
  }

  bookAvailable(args: number): void {
    console.log(args);
    const arr = this.products.controls[args].value;

    this.bookingService.bookSingle(this.customerOrderId, arr as BookingModel).subscribe(
      (_) => this.notification.showMessage('Successfuly', 'Available Inventory Items booked successfuly !!!', 'success'),
      this.handleError
    );
  }

  toolbarClick(args: ClickEventArgs): void {

  }

  back(): void {
    this.location.back();
  }

  onSubmit(): void {

    const arr = this.orderBookingForm.value;
    console.log(arr);
    arr.customerOrderId = this.customerOrderId;
    this.bookingService.bookInBulck(arr)
      .subscribe(
        (_) => this.notification.showMessage('Completed Successfuly', 'Available Inventory items booked successfuly', 'success'),
        this.handleError
      );
  }


}
