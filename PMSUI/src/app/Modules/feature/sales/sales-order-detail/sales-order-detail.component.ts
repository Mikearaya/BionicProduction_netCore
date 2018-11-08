import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { CustomerOrderDetailView } from '../sales-data-model';
import { SaleOrderApiService } from '../sale-order-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { customerOrderDetailBluePrint, invoiceColumnBluePrint, shipmentColumnBluePrint } from './sales-order-detail-blue-print';
import { CommandModel, Grid } from '@syncfusion/ej2-angular-grids';
import { InvoiceSummary } from '../../../core/DataModels/invoice-data-model';
import { CustomErrorResponse } from '../../../core/core-api.service';
import { GridComponent } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-customer-order-detail',
  templateUrl: './sales-order-detail.component.html',
  styleUrls: ['./sales-order-detail.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SalesOrderDetailComponent implements OnInit {
  @ViewChild('invoiceGrid')
  public invoiceGrid: GridComponent;
  public columnBluePrint = customerOrderDetailBluePrint;
  public customerOrder: CustomerOrderDetailView;
  public customerOrderInvoices: InvoiceSummary[];
  public customerOrderShipments;
  private customerOrderId: number;
  public invoiceColumns = invoiceColumnBluePrint;
  public shipmentColumns = shipmentColumnBluePrint;
  public shipmentCommands: CommandModel[];
  public customerOrderCommands: CommandModel[];
  public invoiceCommands: CommandModel[];
  public infoGridAttributes: Object;

  constructor(private salesOrderApi: SaleOrderApiService,
    private activatedRoute: ActivatedRoute,
    private route: Router) {
    this.invoiceColumns = invoiceColumnBluePrint;
    this.infoGridAttributes = {class : 'info-grid-header'};  }

  ngOnInit() {
    this.customerOrderId = +this.activatedRoute.snapshot.paramMap.get('customerOrderId');
    if (this.customerOrderId) {
      this.salesOrderApi.getSalesOrderById(this.customerOrderId).subscribe(
        (data: CustomerOrderDetailView) => this.customerOrder = data,
        (error: HttpErrorResponse) => console.log(error)
      );

      this.salesOrderApi.getSalesOrderInvoices(this.customerOrderId).subscribe(
        (data: InvoiceSummary[]) => this.customerOrderInvoices = data,
        (error: CustomErrorResponse) => console.log(error)
      );
    }

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
    },
    {
      buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-recurrence-01 e-icons'
      }}

    ];

    this.customerOrderCommands = [{
      buttonOption: {
        cssClass: 'e-flat', iconCss: 'e-edit e-icons'
      }
    }
    ];



  }


  viewCustomerOrder(data) {
    this.route.navigate([`sales/${this.customerOrderId}/booking`]);

  }

  viewShipment(data) {
console.log(data);
  }

    addInvoice(): void {
      console.log('in addInvoice');
      this.route.navigate([`invoices/customerorder/${this.customerOrderId}`]);
    }
  viewInvoice(data) {
    this.route.navigate([`invoices/customerorder/${this.customerOrderId}`]);
  }

}
