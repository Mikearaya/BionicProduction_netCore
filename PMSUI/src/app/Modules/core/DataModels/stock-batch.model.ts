export class NewStockBatchModel {
  ItemId: number;
  Quantity: number;
  UnitCost: number;
  PurchaseOrderId: number | null;
  Status: string;
  ManufactureOrderId: number | null;
  AvailableFrom: Date | string;
  ExpiryDate: Date | string | null;

  StorageLocation: StockBatchStorageModel[] = [];
}


export class UpdatedStockBatchModel {
  Id: number;
  Status: string;
  AvailableFrom: Date | string;
  ExpiryDate: Date | string | null;
}


export class StockBatchListView {
  id: number;
  itemId: number;
  quantity: number;
  totalBooked: number;
  unitCost: number;
  status: string;
  storageLocation: string;
  storageLocationId: number;
  purchaseOrderId: number | null;
  manufactureOrderId: number | null;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
  totalCost: number;
  availableFrom: Date | string;
  expiryDate: Date | string | null;
  item: string;
  itemGroup: string;
  itemGroupId: number;
  source: string;
}


export class StockBatchDetailView {

  id: number;
  itemId: number;
  quantity: number;
  totalBooked: number | null;
  unitCost: number;
  status: string;
  purchaseOrderId: number | null;
  manufactureOrderId: number | null;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
  availableFrom: Date | string;
  expiryDate: Date | string | null;
  item: string;
  itemGroup: string;
  itemGroupId: number;
  source: string;

  storages: StockBatchStorageView[] = [];

}



export class StockBatchStorageModel {
  id?: number;
  StorageId: number;
  Quantity: number;
}


export class StockBatchStorageView {
  id: number;
  batchId: number;
  storageId: number;
  storage: string;
  previousStorageId: number | null;
  previousStorage: string;
  quantity: number;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}

