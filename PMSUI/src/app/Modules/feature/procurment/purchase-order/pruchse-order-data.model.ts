export class PurchaseOrderDetailView {

  id: number;
  vendorId: number;
  vendor: string;
  status: string;
  expectedDate: Date | string;
  orderedDate: Date | string | null;
  shippedDate: Date | string | null;
  tax: number | null;
  totalCost: number;
  additionalFee: number | null;
  discount: number | null;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
  orderId: string;
  paymentDate: Date | string | null;
  invoiceId: string;
  invoiceDate: Date | string | null;

  OrderItems: PurchaseOrderItemView[];

}


export class PurchaseOrderItemView {

  lotId: number;
  purchaseOrderId: number;
  itemId: number;
  status: string;
  item: string;
  itemGroupId: number;
  itemGroup: string;
  quantity: number;
  subTotal: number;
  unitPrice: number;
  expectedDate: Date | string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}

export class PurchaseOrderListView {

  id: number;
  vendorId: number;
  vendor: string;
  status: string;
  expectedDate: Date | string;
  orderedDate: Date | string | null;
  shippedDate: Date | string | null;
  arivalDate: Date | string | null;
  tax: number | null;
  totalCost: number;
  additionalFee: number | null;
  discount: number | null;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
  orderId: string;
  paymentDate: Date | string | null;
  invoiceId: string;
  invoiceDate: Date | string | null;


}


export class NewPurchaseOrderModel {
  VendorId: number;
  Status: string;
  ExpectedDate: Date | string;
  OrderedDate: Date | string | null;
  ShippedDate: Date | string | null;
  Tax: number | null;
  AdditionalFee: number | null;
  Discount: number | null;
  OrderId: string;
  PaymentDate: Date | string | null;
  InvoiceId: string;
  InvoiceDate: Date | string | null;
  ArivalDate: Date | string | null;
  PurchaseOrderItems: PurchaseOrderItemModel[] = [];

}


export class PurchaseOrderItemModel {
  Id: number | null;
  ItemId: number;
  Quantity: number;
  UnitPrice: number;
  ExpectedDate: Date | string | null;
}


export class UpdatedPurchaseOrderModel {

  Id: number;
  Status: string;
  ExpectedDate: Date | string;
  OrderedDate: Date | string | null;
  ShippedDate: Date | string | null;
  Tax: number | null;
  AdditionalFee: number | null;
  Discount: number | null;
  OrderId: string;
  PaymentDate: Date | string | null;
  InvoiceId: string;
  InvoiceDate: Date | string | null; PurchaseOrderItems: PurchaseOrderItemModel[];

}
