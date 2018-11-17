export class Shipment {
  id?: number;
  customerOrderId: number;
  bookedBy: number;
  deliveryDate: Date;
  shipmentNote: string;
  status: string;
  shipmentItems: ShipmentItems[] = [];

}

export class ShipmentItems {
  customerOrderItemId: number;
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
  bookedById: number;
  bookingUser: string;
  customerOrderItemId: number;
  itemId: number;
  itemName: string;
  status?: string;
  totalShiped?: number;
  avalableForShipment: number;
  remainingShipment: number;
  orderQuantity: number;

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
