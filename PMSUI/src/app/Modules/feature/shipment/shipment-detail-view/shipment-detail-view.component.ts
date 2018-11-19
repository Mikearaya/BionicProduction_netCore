import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShipmentApiService } from 'src/app/Modules/core/services/shipment/shipment-api.service';
import { ShipmentView } from 'src/app/Modules/core/DataModels/shipment-data.model';
import { shipmentDetailBluePrint } from '../shipment-view/shipment-view-blue-print';
import { CommonProperties } from 'src/app/Modules/core/DataModels/common-properties.class';

@Component({
  selector: 'app-shipment-detail-view',
  templateUrl: './shipment-detail-view.component.html',
  styleUrls: ['./shipment-detail-view.component.css']
})

export class ShipmentDetailViewComponent extends CommonProperties implements OnInit {
  private shipmentId: number;
  public shipment: ShipmentView;
  public columnBluePrint = shipmentDetailBluePrint;
  customAttributes: { class: string; };

  constructor(private activatedRoute: ActivatedRoute,
    private shipmentApi: ShipmentApiService) {
    super();
    this.customAttributes = { class: 'info-grid-header' };
  }

  ngOnInit() {

    this.shipmentId = + this.activatedRoute.snapshot.paramMap.get('shipmentId');

    if (this.shipmentId) {
      this.shipmentApi.getShipmentById(this.shipmentId).subscribe(
        (data: ShipmentView) => this.shipment = data,
        this.handleError
      );
    }
  }

}
