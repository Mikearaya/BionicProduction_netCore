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
        manufacturingUomId: number | null;
        manufacturingUom: string;
        storingUomId: number;
        storingUom: string;
        shelfLife: number | null;
        groupId: number;
        group: string;
        dateUpdated: Date | string | null;
        dateAdded: Date | string | null;
    }