export class PurchaseRecievingModel {
  PurchaseOrderId: number;
  RecievedItems: PurchaseRecievingItemModel[] = [];
}


export class PurchaseRecievingItemModel {
  LotId: number;
  Quantity: number;
}
