export class Shipment {
  id: number;
  customerOrderId: number;
  bookedBy: number;
  deliveryDate: Date;
  shipmentNote: string;
  status: string;
  shimentItems: ShipmentItems[] = [];

}

export class ShipmentItems {
  orderItemId: number;
  quantity: number;
}

export class ShipmentView {
  id?: number;
  customerOrderId: number;
  deliveryDate: Date;
  createdOn: Date;
  bookedBy: number;
  status: string;
  shipmentDetail: ShipmentViewDetail[] = [];
}

export class ShipmentViewDetail {
  id?: number;
  orderItemId: number;
  itemId: number;
  itemName: string;
  status?: string;
  pickedQuantity?: number;
  bookedQuantity: number;
  remainingShipment: number;
  orderedQuantity: number;

}


export class ShipmentSummaryView {
  id: number;
  customerOrderId: number;
  customerName: string;
  planedShipment: number;
  actualShiped: number;
  remaingShipment: number;
  status: string;
  deliveryDate: Date;
  createdOn: Date;
  dateupdated: Date;
  bookedById: number;
  bookerName: string;
}

export class ShipmentSummary {
  id: number;
  dateAdded: number;
  deliveryDate: number;
}
