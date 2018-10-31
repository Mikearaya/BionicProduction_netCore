

export class CustomerOrder {
  Id?: number;
  ClientId: number;
  CreatedBy: number;
  DateAdded?: Date;
  DateUpdated?: Date;
  Description: string;
  InitialPayment: number;
  PaymentMethod: string;
  PurchaseOrderDetail: CustomerOrderDetail[] = [];

}

export class CustomerOrderDetail {
  Id?: number;
  ItemId: number;
  PricePerItem: number;
  PurchaseOrderId?: number;
  Quantity: number;
}
