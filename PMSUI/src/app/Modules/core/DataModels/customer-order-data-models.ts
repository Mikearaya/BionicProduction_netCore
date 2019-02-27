

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

export class NewCustomerOrderModel {
  Status: string;
  ClientId: number;
  Description: string;
  DeliveryDate: Date | string | null;

  CustomerOrderDetail: CustomerOrderItemModel[] = [];
}

export class CustomerOrderItemModel {
  Id?: number | null;
  ItemId: number;
  Quantity: number;
  DueDate: Date | string;
  UnitPrice: number;

}

export class CustomerOrderDetailView {

  Id: number;
  CustomerId: number;
  CustomerName: string;
  Status: string;
  DeliveryDate: Date | string | null;
  DateAdded: Date | string | null;
  DateUpdated: Date | string | null;

  CreatedBy: string;
  Reference: string;
  Description: string;
  Discount: number;
  CustomerOrderItems: CustomerOrderItemView[] = [];

}

export interface CustomerOrderItemView {
  Id: number;
  ItemId: number;
  Quantity: number;
  UnitPrice: number;
  SubTotal: number;
  TotalCost: number;
  Profit: number;
  Status: string;
  ManufactureOrderId: number;
  DeliveryDate: Date | string | null;
  TotalShipped: number | null;
}


export class CustomerOrderListView {
  Id: number;
  TotalQuantity: number;
  CustomerId: number;
  CustomerName: string;
  TotalPrice: number | null;

  TotalCost: number | null;
  Profit: number;
  Status: string;
  ProductStatus: string;
  InvoiceStatus: string;
  PaymentStatus: string;
  totalShipped: number | null;
  CreatedBy: string;
  DateAdded: Date | string | null;
  DateUpdated: Date | string | null;
  DeliveryDate: Date | string | null;

}
