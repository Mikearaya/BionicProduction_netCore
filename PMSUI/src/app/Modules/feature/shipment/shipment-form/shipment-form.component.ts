import { Component, OnInit, Inject } from '@angular/core';
import { ShipmentApiService } from '../shipment-api.service';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { ShipmentItems } from 'src/app/Modules/core/DataModels/shipment-data.model';
import { Query, DataManager, WebApiAdaptor, ReturnOption } from '@syncfusion/ej2-data';

@Component({
  selector: 'app-shipment-form',
  templateUrl: './shipment-form.component.html',
  styleUrls: ['./shipment-form.component.css']
})
export class ShipmentFormComponent implements OnInit {
  public shipmentForm: FormGroup;
  public orderList: Object[];
  public orderQuery: Query;
  public orderFields: { text: string; value: string; };

  constructor(private shipmentApi: ShipmentApiService,
    private formBuilder: FormBuilder,
    @Inject('BASE_URL') private apiUrl: string) {

    this.orderQuery = new Query().select(['id']);
    this.orderFields = { text: 'id', value: 'id' };

    this.createForm();
  }

  ngOnInit() {
    const order: DataManager = new DataManager(
      { url: `${this.apiUrl}/workorders?status=active`, adaptor: new WebApiAdaptor, offline: true },
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

  initializeShipmentItems(data: ShipmentItems): FormGroup {
    return this.formBuilder.group({
      orderItemId: [data.orderItemId],
      quantity: [data.quantity, Validators.min(0)]
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

  }
}
