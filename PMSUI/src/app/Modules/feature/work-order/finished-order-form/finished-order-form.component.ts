import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { Query, WebApiAdaptor, DataManager, ReturnOption } from '@syncfusion/ej2-data';
import { Location } from '@angular/common';
import { FinishedOrderApiService } from '../finished-order-api.service';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';


@Component({
  selector: 'app-finished-order-form',
  templateUrl: './finished-order-form.component.html',
  styleUrls: ['./finished-order-form.component.css']
})
export class FinishedOrderFormComponent extends CommonProperties implements OnInit {
  @ViewChild('notification')
  private notification: NotificationComponent;

  public finishedProductsForm: FormGroup;
  public employeeQuery: Query;
  public employeeFields: Object;
  public orderQuery: Query;
  public orderFields: Object;
  public employeeList: any[];
  public orderList: any[];

  constructor(private formBuilder: FormBuilder,
    private finishedProductsApi: FinishedOrderApiService,
    private location: Location,
    @Inject('BASE_URL') private apiUrl: string) {
    super();
    this.employeeQuery = new Query().select(['firstName', 'id']);
    this.employeeFields = { text: 'firstName', value: 'id' };
    this.orderQuery = new Query().select(['id']);
    this.orderFields = { text: 'id', value: 'id' };
    this.createForm();
  }

  ngOnInit() {
    const employee: DataManager = new DataManager(
      { url: `${this.apiUrl}/employees`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );
    employee.ready.then((e: ReturnOption) => this.employeeList = <Object[]>e.result).catch((e) => true);

    const order: DataManager = new DataManager(
      { url: `${this.apiUrl}/workorders?status=active`, adaptor: new WebApiAdaptor, offline: true },
      new Query().take(8)
    );

    order.ready.then((e: ReturnOption) => this.orderList = <Object[]>e.result).catch((e) => true);

  }

  createForm() {
    this.finishedProductsForm = this.formBuilder.group({
      submitionForm: this.formBuilder.array([
        this.form()
      ])

    });

  }

  form(): FormGroup {
    return this.formBuilder.group({
      orderId: ['', Validators.required],
      quantity: ['', [Validators.required, Validators.min(0)]],
      submitedBy: ['', Validators.required],
      recievedBy: ['', Validators.required]
    });

  }

  get submitionForm(): FormArray {
    return this.finishedProductsForm.get('submitionForm') as FormArray;
  }

  addForm() {
    this.submitionForm.push(this.form());
  }

  onSubmit() {
    const form = this.submitionForm.value;

    this.finishedProductsApi.addFinishedProduct(form).subscribe(
      (success) => {
        this.notification.showMessage( 'Products added to inventory Successfuly'),
          this.location.back();
      },
      this.handleError
    );
  }

}
