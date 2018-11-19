import { Component, OnInit, Inject } from '@angular/core';
import { ShipmentApiService } from '../../../core/services/shipment/shipment-api.service';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { ShipmentItems, ShipmentViewDetail, Shipment } from 'src/app/Modules/core/DataModels/shipment-data.model';
import { Query, DataManager, WebApiAdaptor, ReturnOption } from '@syncfusion/ej2-data';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-shipment-form',
  templateUrl: './shipment-form.component.html',
  styleUrls: ['./shipment-form.component.css']
})
export class ShipmentFormComponent extends CommonProperties implements OnInit {
  public shipmentForm: FormGroup;
  public orderList: Object[];
  public orderQuery: Query;
  public orderFields: { text: string; value: string; };
  public customerOrder: number;
  public orderItems: ShipmentViewDetail[];
  employeeQuery: Query;
  employeeFields: { text: string; value: string; };
  employeesList: Object[];

  constructor(private shipmentApi: ShipmentApiService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    public router: Router,
    @Inject('BASE_URL') private apiUrl: string) {
    super();
    this.createForm();
    this.orderQuery = new Query().select(['id']);
    this.orderFields = { text: 'id', value: 'id' };
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };

  }

  ngOnInit() {
    this.customerOrder = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');
    if (this.customerOrder) {
      this.createForm();
      this.shipmentApi.getCustomerOrderShipments(this.customerOrder).subscribe(
        (data: ShipmentViewDetail[]) => this.initializeForm(data),
        this.handleError
      );
    }


    const employeeDataManaget: DataManager = new DataManager(
      { url: `${this.apiUrl}/employees`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    employeeDataManaget.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);

    const order: DataManager = new DataManager(
      { url: `${this.apiUrl}/salesorders?status=active`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    order.ready.then((e: ReturnOption) => this.orderList = <Object[]>e.result).catch((e) => true);
  }

  createForm(): void {
    this.shipmentForm = this.formBuilder.group({
      customerOrderId: ['', Validators.required],
      bookedBy: ['', Validators.required],
      deliveryDate: ['', Validators.required],
      shipmentNote: '',
      shipmentItems: this.formBuilder.array([])
    });
  }

  initializeShipmentItems(data: ShipmentViewDetail): FormGroup {
    return this.formBuilder.group({
      orderItemId: [data.customerOrderItemId],
      quantity: [data.avalableForShipment, [Validators.min(0), Validators.max(data.avalableForShipment)]]
    });
  }

  initializeForm(data: ShipmentViewDetail[]) {
    this.orderItems = data;

    const orderId = data[0].customerOrderId;


    data.forEach(element => {
      this.shipmentItems.push(this.initializeShipmentItems(element));
      this.customerOrderId.setValue(orderId);
    });

  }

  get shipmentItems(): FormArray {
    return this.shipmentForm.get('shipmentItems') as FormArray;
  }

  get customerOrderId(): FormControl {
    return this.shipmentForm.get('customerOrderId') as FormControl;
  }

  get deliveryDate(): FormControl {
    return this.shipmentForm.get('deliveryDate') as FormControl;
  }

  get shipmentNote(): FormControl {
    return this.shipmentForm.get('shipmentNote') as FormControl;
  }
  get bookedBy(): FormControl {
    return this.shipmentForm.get('bookedBy') as FormControl;
  }

  onSubmit(): void {
    alert('Submitted');
    const shipment: Shipment = this.prepateData();
    this.shipmentApi.createNewShipment(shipment).subscribe(
      (data: Shipment) => {
        alert('Shipment Created Successfuly');
        this.router.navigate([`shipments/${data.id}`]);
      },
      this.handleError
    );

  }

  prepateData(): Shipment {
    const formData = this.shipmentForm.value;
    const shipmentData: Shipment = {
      customerOrderId: formData.customerOrderId,
      deliveryDate: formData.deliveryDate,
      shipmentNote: formData.shipmentNote,
      bookedBy: formData.bookedBy,
      status: 'new',
      shipmentItems: []
    };
    const c = this.shipmentItems.value;
    c.forEach(element => {
      shipmentData.shipmentItems.push({
        customerOrderItemId: element.orderItemId,
        quantity: element.quantity
      });
    });

    return shipmentData;
  }
}
