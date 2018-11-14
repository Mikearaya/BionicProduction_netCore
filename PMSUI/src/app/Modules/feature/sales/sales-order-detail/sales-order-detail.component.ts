/*
 * @CreateTime: Nov 11, 2018 12:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 10:18 PM
 * @Description: Modify Here, Please
 */
import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { GridComponent, CommandModel, Column, IRow } from '@syncfusion/ej2-angular-grids';

import { CustomerOrderDetailView } from '../sales-data-model';
import { SaleOrderApiService } from '../sale-order-api.service';
import { customerOrderDetailBluePrint, invoiceColumnBluePrint, shipmentColumnBluePrint } from './sales-order-detail-blue-print';
import { InvoiceSummary } from '../../../core/DataModels/invoice-data-model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';
import { closest } from '@syncfusion/ej2-base';

@Component({
  selector: 'app-customer-order-detail',
  templateUrl: './sales-order-detail.component.html',
  styleUrls: ['./sales-order-detail.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class SalesOrderDetailComponent extends CommonProperties implements OnInit {
  @ViewChild('invoiceGrid')
  public invoiceGrid: GridComponent;
  public columnBluePrint = customerOrderDetailBluePrint;
  public customerOrder: CustomerOrderDetailView;
  public customerOrderInvoices: InvoiceSummary[];
  public customerOrderShipments;
  public invoiceColumns = invoiceColumnBluePrint;
  public shipmentColumns = shipmentColumnBluePrint;
  public shipmentCommands: CommandModel[];
  public customerOrderCommands: CommandModel[];
  public invoiceCommands: CommandModel[];
  public infoGridAttributes: Object;
  public errorDescription: any;
  public errorMessage: string;

  private customerOrderId: number;

  constructor(
    private salesOrderApi: SaleOrderApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {
    super();
    this.invoiceColumns = invoiceColumnBluePrint;
    this.infoGridAttributes = { class: 'info-grid-header' };




  }

  ngOnInit(): void {
    this.customerOrderId = +this.activatedRoute.snapshot.paramMap.get('customerOrderId');

    if (this.customerOrderId) {
      this.salesOrderApi.getSalesOrderById(this.customerOrderId).subscribe(
        (data: CustomerOrderDetailView) => this.customerOrder = data,
        this.handleError
      );

      this.salesOrderApi.getSalesOrderInvoices(this.customerOrderId).subscribe(
        (data: InvoiceSummary[]) => this.customerOrderInvoices = data,
        this.handleError
      );
    }
    this.invoiceCommands = [{
      buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-edit e-icons',
        click: this.viewInvoice.bind(this)
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


  addNewOrderItem(): void {
    this.route.navigate([`sales/${this.customerOrderId}/update`]);
  }

  bookOrderItems(): void {
    this.route.navigate([`sales/${this.customerOrderId}/booking`]);
  }

  addInvoice(): void {
    this.route.navigate([`invoices/customerorder/${this.customerOrderId}`]);
  }
  viewInvoice(args: Event): void {
    const rowObj: IRow<Column> = this.invoiceGrid.getRowObjectFromUID(closest(<Element>args.target, '.e-row').getAttribute('data-uid'));
    this.route.navigate([`invoices/${rowObj.data['Id']}`]);
  }

}
