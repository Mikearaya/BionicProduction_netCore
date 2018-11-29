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





export class ItemModel {
  id: number;
  code: string;
  name: string;
  minimumQuantity: number;
  description: string;
  weight: number;
  unitCost: number;
  image: string;
  isInventoryItem: number;
  isProcured: number;
  manufacturingUomId: number;
  stockUomId: number;
  price: number | null;
  shelfLife: number | null;
  groupId: number;

}


export interface ItemViewModel {

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

  averageCost: number;
}
