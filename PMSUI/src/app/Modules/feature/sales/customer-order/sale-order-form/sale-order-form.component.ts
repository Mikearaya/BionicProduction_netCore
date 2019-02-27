import { ActivatedRoute, Router } from '@angular/router';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import {
  Component,
  Inject,
  OnInit,
  ViewChild
} from '@angular/core';
import { Customer } from 'src/app/Modules/core/DataModels/customer-data.model';
import { CustomerOrderApiService } from '../customer-order-api.service';
import {
  CustomerOrderDetailView,
  CustomerOrderItemModel,
  CustomerOrderItemView,
  NewCustomerOrderModel
} from 'src/app/Modules/core/DataModels/customer-order-data-models';
import { CustomerService } from 'src/app/Modules/core/services/customers/customer.service';
import {
  DataManager,
  Query,
  ReturnOption,
  WebApiAdaptor
} from '@syncfusion/ej2-data';
import { Employee, EmployeeApiService } from 'src/app/Modules/core/services/employees/employee-api.service';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { ItemApiService } from 'src/app/Modules/core/services/item/item-api.service';
import { ItemView } from 'src/app/Modules/core/DataModels/item-data-models';
import { Location } from '@angular/common';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
/*
 * @CreateTime: Nov 9, 2018 1:35 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 12:26 AM
 * @Description: Modify Here, Please
 */

@Component({
  selector: 'app-sale-order-form',
  templateUrl: './sale-order-form.component.html',
  styleUrls: ['./sale-order-form.component.css']
})
export class SaleOrderFormComponent extends CommonProperties implements OnInit {

  @ViewChild('notification') notification: NotificationComponent;

  public isVisable: Boolean = false;
  private customerOrderId: number;
  public isUpdate: Boolean;

  private orderData: CustomerOrderDetailView;
  public salesOrderForm: FormGroup;
  public itemId: FormControl;
  public errors: Object[] = [];
  public customersQuery: Query;
  public customerFields: Object;
  public itemQuery: Query;
  public itemFields: Object;
  public itemsList: any[];
  public employeesList: any[];
  public customersList: any[];
  public today: Date;
  public orderStatus = ['Quotation', 'Waiting for Confirmation', 'Confirmed', 'Canceled', 'Delivered'];
  public errorDescription: any;

  constructor(
    private customerOrderApi: CustomerOrderApiService,
    private formBuilder: FormBuilder,
    private itemApi: ItemApiService,
    private customerApi: CustomerService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {

    super();
    this.createForm();
    this.today = new Date();
    this.customersQuery = new Query().select(['fullName', 'id']);
    this.customerFields = { text: 'fullName', value: 'id' };
    this.itemQuery = new Query().select(['name', 'id']);
    this.itemFields = { text: 'name', value: 'id' };

  }

  ngOnInit(): void {
    this.customerOrderId = + this.activatedRoute.snapshot.paramMap.get('customerOrderId');

    if (this.customerOrderId) {
      this.isUpdate = true;
      this.customerOrderApi.getCustomerOrderById(this.customerOrderId).subscribe(
        (data: CustomerOrderDetailView) => this.orderData = data,
        this.handleError
      );
    }

    this.itemApi.getAllItems().subscribe(
      (data: ItemView[]) => this.itemsList = data,
      this.handleError
    );

    this.customerApi.getAllCustomers().subscribe(
      (data: Customer[]) => this.customersList = data,
      this.handleError
    );



  }

  createForm(): void {
    this.salesOrderForm = this.formBuilder.group({
      client: ['', Validators.required],
      deliveryDate: ['', Validators.required],
      status: ['Quotation', Validators.required],
      description: [''],
      orders: this.formBuilder.array([
        this.formBuilder.group({
          itemId: ['', Validators.required],
          unitPrice: [0, [Validators.required, Validators.min(0)]],
          quantity: [1, [Validators.required, Validators.min(1)]],
          dueDate: ['', Validators.required]
        })
      ])
    });
  }

  initializeForm(data: CustomerOrderDetailView): void {
    this.salesOrderForm = this.formBuilder.group({
      client: [data.CustomerId, Validators.required],
      deliveryDate: [data.DeliveryDate, Validators.required],
      status: [data.Status, Validators.required],
      description: [data.Description],
      orders: this.formBuilder.array(data.CustomerOrderItems.map(order => this.initializeOrderItems(order)))
    });

  }

  get orderedBy(): FormControl {
    return this.salesOrderForm.get('orderedBy') as FormControl;
  }

  get deliveryDate(): FormControl {
    return this.salesOrderForm.get('deliveryDate') as FormControl;
  }

  get status(): FormControl {
    return this.salesOrderForm.get('status') as FormControl;
  }

  get client(): FormControl {
    return this.salesOrderForm.get('client') as FormControl;
  }
  get orders(): FormArray {
    return this.salesOrderForm.get('orders') as FormArray;
  }

  addOrder() {
    this.orders.push(this.formBuilder.group({
      itemId: ['', Validators.required],
      unitPrice: [0, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(0)]],
      dueDate: ['', Validators.required]
    }));
  }

  initializeOrderItems(data: CustomerOrderItemView): FormGroup {
    return this.formBuilder.group({
      id: [data.Id, Validators.required],
      itemId: [data.ItemId, Validators.required],
      unitPrice: [data.UnitPrice, [Validators.required]],
      quantity: [data.Quantity, [Validators.required, Validators.min(0)]],
      dueDate: [data.DeliveryDate, Validators.required]
    });
  }




  onSubmit() {
    const form = this.salesOrderForm.value;


    if (!this.isUpdate) {
      const order = this.prepareNewFormData(form);
      this.customerOrderApi.createSalesOrder(order).subscribe(
        (co: CustomerOrderDetailView) => {
          this.notification.showMessage('Customer order Created Successfuly');
          this.route.navigate([`../${co.Id}/booking`], { relativeTo: this.activatedRoute });
        },
        this.handleError
      );
    } else {

    }
  }

  prepareNewFormData(form: any): NewCustomerOrderModel {
    const order = new NewCustomerOrderModel();
    order.ClientId = (form.client) ? form.client : null;
    order.Description = form.description;
    order.Status = form.status;
    order.DeliveryDate = form.deliveryDate;
    form.orders.forEach(element => {
      order.CustomerOrderDetail.push({
        ItemId: element.itemId,
        Quantity: element.quantity,
        DueDate: element.dueDate,
        UnitPrice: element.unitPrice
      });
    });

    return order;
  }


}
