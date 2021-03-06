export class LowStockItemsView {

  id: number;
  productName: string;
  productCode: string;
  availableQuantity: number;
  expectedAvailableQuantity: number;
  required: number;
  inStock: number;
  minimumQuantity: number;
}

export class VendorItemViewModel {
  id: number;
  code: string;
  name: string;
  minimumQuantity: number | null;
  price: number | null;
  vendorItemCode: string;
  priority: number | null;
  photo: string;
  primaryUomId: number;
  primaryUom: string;
  groupId: number;
  leadTime: number | null;
  group: string;
  dateUpdated: Date | string | null;
  dateAdded: Date | string | null;
}



export class ItemModel {
  id: number;
  code: string;
  name: string;
  minimumQuantity: number;
  description: string;
  weight: number;
  unitCost: number;
  defaultStorageId: number;
  image: string;
  isInventoryItem: number;
  isProcured: number;
  primaryUomId: number;
  price: number | null;
  shelfLife: number | null;
  groupId: number;

}


export interface StockView {

  itemId: number;

  itemName: string;

  itemCode: string;

  inStock: number;
  available: number;

  booked: number;

  totalExpected: number;

  expectedAvailable: number;

  expectedBooked: number;

  totalCost: number;
  defaultStorageId: number;
  defaultStorage: string;

  averageCost: number;
}

export interface ItemView {
  id: number;
  code: string;
  name: string;
  minimumQuantity: number | null;
  description: string;
  weight: number | null;
  unitCost: number;
  price: number | null;
  storingUoM: string;
  photo: string;
  isInventoryItem: number | null;
  isProcured: number | null;
  defaultStorageId: number;
  defaultStorage: string;
  primaryUomId: number;
  primaryUom: string;
  shelfLife: number | null;
  groupId: number;
  group: string;
  dateUpdated: Date | string | null;
  dateAdded: Date | string | null;
}

export class ItemReportModel {
  id: number;
  item: string;
  itemCode: string;
  inStock: number;
  available: number;
  booked: number;
  totalExpected: number;
  totalWriteOff: number;
  expectedAvailable: number;
  expectedBooked: number;
  minimumQuantity: number | null;
  primaryUom: string;
  primaryUomId: number;
  totalCost: number;
  averageCost: number;
}


export interface CriticalItemModel {
  id: number;
  itemName: string;
  itemCode: string;
  required: number;
  minimumQuantity: number;
  availableQuantity: number;
  expectedAvailableQuantity: number;
  uom: string;
  inStock: number;
}
