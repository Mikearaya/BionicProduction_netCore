import { Component, OnInit, ViewChild } from '@angular/core';
import { WorkOrderAPIService, PendingManufactureOrdersView, WorkOrder, WorkOrderView } from '../work-order-api.service';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { GridComponent, RowSelectEventArgs, SaveEventArgs } from '@syncfusion/ej2-ng-grids';
import { Query, DataManager, WebApiAdaptor, ReturnOption } from '@syncfusion/ej2-data';


@Component({
  selector: 'app-requested-work-order-form',
  templateUrl: './requested-work-order-form.component.html',
  styleUrls: ['./requested-work-order-form.component.css']
})
export class RequestedWorkOrderFormComponent implements OnInit {

  public employeeQuery: Query;
  public employeeFields: Object;
  public employeesList: any[];

  private salesOrderId: number;
  public salesOrder: PendingManufactureOrdersView[] = [];
  public workRequestForm: FormGroup;
  public dropData: string[];
  public saleOrder: any;

  constructor(
    private workOrderApi: WorkOrderAPIService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder) {
     this.createForm();
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };

  }

  ngOnInit() {
    this.salesOrderId = + this.activatedRoute.snapshot.paramMap.get('salesOrderId');
    this.workOrderApi.getWorkOrderRequestById(this.salesOrderId)
      .subscribe(
        (data: PendingManufactureOrdersView[]) => this.addForm(data),
        (error: HttpErrorResponse) => console.log(error)
      );
    const dm: DataManager = new DataManager(
      { url: 'http://localhost:5000/api/employees', adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    dm.ready.then((e: ReturnOption) => this.employeesList = <Object[]>e.result).catch((e) => true);
  }

  onSubmit() {
    const form = this.workRequestForm.value;
    console.log(form);

  }
  createForm() {
    this.workRequestForm = this.formBuilder.group({
      orderedBy: ['', Validators.required],
      description: ['', Validators.required],
      salesOrderId: ['', Validators.required],
      items: this.formBuilder.array([])
    });
  }



  get items(): FormArray {
    return this.workRequestForm.get('items') as FormArray;
  }

  addForm(requestedItems: PendingManufactureOrdersView[]) {
    console.log(this.workRequestForm);
    this.saleOrder = requestedItems;
    this.workRequestForm = this.formBuilder.group({
      orderedBy: [requestedItems[0].orderedBy, Validators.required],
      description: ['', Validators.required],
      salesOrderId: [this.salesOrderId, Validators.required],
      items: this.formBuilder.array([])
    });

    requestedItems.forEach(element => {
      const maxQuantity: number = + element.quantity;
      this.items.push(this.formBuilder.group({
        salesOrderId: [element.salesOrderItemId, Validators.required],
        itemId: [element.product, Validators.required],
        start: ['', Validators.required],
        end: ['', Validators.required],
        quantity: [0, [Validators.required, Validators.min(0), Validators.max(maxQuantity)]],
        dueDate: [element.dueDate, Validators.required]
      }));
    });
  }


}