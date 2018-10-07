import { Component, OnInit, ViewChild } from '@angular/core';
import { WorkOrderAPIService, PendingManufactureOrdersView } from '../work-order-api.service';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { data } from './datasource';
import { GridComponent } from '@syncfusion/ej2-ng-grids';


@Component({
  selector: 'app-requested-work-order-form',
  templateUrl: './requested-work-order-form.component.html',
  styleUrls: ['./requested-work-order-form.component.css']
})
export class RequestedWorkOrderFormComponent implements OnInit {

  @ViewChild('grid')
  public grid: GridComponent;



  private purchaseOrderId: number;
  public requestedItems: PendingManufactureOrdersView[];
  public workRequestForm: FormGroup;
  public dropData: string[];
  public dataaa: any;
  constructor(private workOrderApi: WorkOrderAPIService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) {

    this.createForm();
  }

  ngOnInit() {
    this.purchaseOrderId = + this.activatedRoute.snapshot.paramMap.get('salesOrderId');
    this.workOrderApi.getPendingWorkOrderById(this.purchaseOrderId)
      .subscribe(
        (dataa: PendingManufactureOrdersView[]) => this.requestedItems = dataa,
        (error: HttpErrorResponse) => console.log(error)
      );

    this.dataaa = data;
    this.dropData = ['Order Placed', 'Processing', 'Delivered'];

  }

  createForm() {
    this.workRequestForm = this.formBuilder.group({
      orderedBy: ['', Validators.required],
      description: ['', Validators.required],
      orders: this.formBuilder.array([

      ])
    });
  }

  get orders() {
    return this.workRequestForm.get('orders') as FormArray;
  }

  addForm(requestedItems: PendingManufactureOrdersView[]) {

    this.workRequestForm = this.formBuilder.group({
      requestedBy: [requestedItems[0].orderedBy, Validators.required],
      description: ['', Validators.required],
      salesOrderId: [this.purchaseOrderId, Validators.required],
      orderedBy: ['', Validators.required],
    });

    requestedItems.forEach(element => {
      this.orders.push(this.formBuilder.group({
        salesOrderItemId: [element.purchaseOrderItemId, Validators.required],
        itemId: [element.product, Validators.required],
        approvedQuantity: [element.quantity, [Validators.required, Validators.min(0)]],
        dueDate: [element.dueDate, [Validators.required, Validators.min]]
      }));
    });
  }


}
