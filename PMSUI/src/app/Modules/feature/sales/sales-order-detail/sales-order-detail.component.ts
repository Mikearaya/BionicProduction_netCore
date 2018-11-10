import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

import { GridComponent, CommandModel } from '@syncfusion/ej2-angular-grids';

import { CustomerOrderDetailView } from '../sales-data-model';
import { SaleOrderApiService } from '../sale-order-api.service';
import { customerOrderDetailBluePrint, invoiceColumnBluePrint, shipmentColumnBluePrint } from './sales-order-detail-blue-print';
import { InvoiceSummary } from '../../../core/DataModels/invoice-data-model';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

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

    constructor(private salesOrderApi: SaleOrderApiService,
        private activatedRoute: ActivatedRoute,
        private route: Router
    ) {
      super();
        this.invoiceColumns = invoiceColumnBluePrint;
        this.infoGridAttributes = { class: 'info-grid-header' };

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
    viewInvoice(data): void {
        this.route.navigate([`invoices/customerorder/${this.customerOrderId}`]);
    }

}
