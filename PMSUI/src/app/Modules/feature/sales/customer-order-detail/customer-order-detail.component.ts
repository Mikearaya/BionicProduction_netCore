import { Component, OnInit } from '@angular/core';
import { CustomerOrderDetailView } from '../data-model';
import { SaleOrderApiService } from '../sale-order-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { customerOrderDetailBluePrint, invoiceColumnBluePrint, shipmentColumnBluePrint } from './customer-order-detail-blue-print';
import { CommandModel } from '@syncfusion/ej2-grids';

@Component({
  selector: 'app-customer-order-detail',
  templateUrl: './customer-order-detail.component.html',
  styleUrls: ['./customer-order-detail.component.css']
})
export class CustomerOrderDetailComponent implements OnInit {
  public columnBluePrint = customerOrderDetailBluePrint;
  public customerOrder: CustomerOrderDetailView;
  public customerOrderInvoices;
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
    }
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

  }

  viewInvoice(data) {

  }

}
