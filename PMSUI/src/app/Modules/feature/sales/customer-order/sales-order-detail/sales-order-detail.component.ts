/*
 * @CreateTime: Nov 11, 2018 12:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 26, 2018 10:22 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { GridComponent, CommandModel, Column, IRow } from '@syncfusion/ej2-angular-grids';
import { CustomerOrderApiService } from '../customer-order-api.service';
import { customerOrderDetailBluePrint, invoiceColumnBluePrint, shipmentColumnBluePrint } from './sales-order-detail-blue-print';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { closest } from '@syncfusion/ej2-base';
import { ShipmentSummary } from 'src/app/Modules/core/DataModels/shipment-data.model';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NotificationComponent } from 'src/app/Modules/shared/notification/notification.component';
import { InvoiceSummary } from 'src/app/Modules/core/DataModels/invoice-data-model';
import { CustomerOrderDetailView } from 'src/app/Modules/core/DataModels/customer-order-data-models';

@Component({
  selector: 'app-customer-order-detail',
  templateUrl: './sales-order-detail.component.html',
  styleUrls: ['./sales-order-detail.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class SalesOrderDetailComponent extends CommonProperties implements OnInit {
  public orderStatus = ['Quotation', 'Waiting for Confirmation', 'Confirmed', 'Canceled', 'Delivered'];
  @ViewChild('invoiceGrid')
  public invoiceGrid: GridComponent;
  @ViewChild('shipmentGrid')
  public shipmentGrid: GridComponent;
  @ViewChild('notification')
  private notification: NotificationComponent;

  public columnBluePrint = customerOrderDetailBluePrint;
  public customerOrder: CustomerOrderDetailView;
  public customerOrderInvoices: InvoiceSummary[];
  public customerOrderShipments: ShipmentSummary[];
  public invoiceColumns = invoiceColumnBluePrint;
  public shipmentColumns = shipmentColumnBluePrint;
  public shipmentCommands: CommandModel[];
  public customerOrderCommands: CommandModel[];
  public invoiceCommands: CommandModel[];
  public infoGridAttributes: Object;
  public errorDescription: any;
  public errorMessage: string;
  public orderStatusForm: FormGroup;

  private customerOrderId: number;

  constructor(
    private customerOrderApi: CustomerOrderApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private formBuilder: FormBuilder
  ) {
    super();
    this.customerOrder = new CustomerOrderDetailView();
    this.initializeOrderStatus();

    this.invoiceColumns = invoiceColumnBluePrint;
    this.infoGridAttributes = { class: 'info-grid-header' };
    this.invoiceCommands = [{
      buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-edit e-icons',
        click: this.viewInvoice.bind(this)
      }
    }
    ];
    this.shipmentCommands = [{
      buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-edit e-icons',
        click: this.viewShipment.bind(this)
      }
    }
    ];

    this.customerOrderCommands = [{
      buttonOption: {
        cssClass: 'e-flat',
        iconCss: 'e-edit e-icons'
      }
    }];



  }

  // used to show order status dropdown based on the status of customer order
  showDrobbox() {

    switch (this.customerOrder.Status.toUpperCase()) {
      case 'CONFIRMED':
        return false;
      case 'QUOTATION':
        return true;
      default:
        return false;
    }

  }


  get statusInput(): FormControl {
    return this.orderStatusForm.get('statusInput') as FormControl;
  }

  initializeOrderStatus(status: String = ''): void {
    this.orderStatusForm = this.formBuilder.group({
      statusInput: [status, Validators.required]
    });
  }

  ngOnInit(): void {
    this.customerOrderId = +this.activatedRoute.snapshot.paramMap.get('customerOrderId');

    if (this.customerOrderId) {
      this.customerOrderApi.getCustomerOrderById(this.customerOrderId).subscribe(
        (data: CustomerOrderDetailView) => {
          this.customerOrder = data;
          this.initializeOrderStatus(data.Status);
        },
        this.handleError
      );

      this.customerOrderApi.getSalesOrderInvoices(this.customerOrderId).subscribe(
        (data: InvoiceSummary[]) => this.customerOrderInvoices = data,
        this.handleError
      );

      this.customerOrderApi.getCustomerOrderShipmentsSummary(this.customerOrderId).subscribe(
        (data: ShipmentSummary[]) => this.customerOrderShipments = data,
        this.handleError
      );
    }

  }


  addNewOrderItem(): void {
    this.route.navigate([`update`], { relativeTo: this.activatedRoute });
  }

  bookOrderItems(): void {
    this.route.navigate([`booking`], { relativeTo: this.activatedRoute });
  }

  addInvoice(): void {
    this.route.navigate([`invoices/customerorder/${this.customerOrderId}`]);
  }

  addShipment(): void {
    this.route.navigate([`shipments/customerorder/${this.customerOrderId}`]);
  }
  viewInvoice(args: Event): void {
    const rowObj: IRow<Column> = this.invoiceGrid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`invoices/${rowObj.data['Id']}`]);
  }

  viewShipment(args: Event): void {
    const rowObj: IRow<Column> = this.shipmentGrid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`shipments/${rowObj.data['id']}`]);
  }

  deleteOrder(id: number): void {

    this.customerOrderApi.deleteSalesOrder(id).subscribe(
      (_) => this.notification.showMessage('Customer order Deleted Successfuly'),
      this.handleError
    );
  }
  updateOrderStatus() {
    this.customerOrderApi.updateCustomerOrderStatus(this.customerOrderId, this.statusInput.value).subscribe(
      (_) => this.notification.showMessage('Customer order Updated Successfuly'),
      this.handleError
    );

  }
}
