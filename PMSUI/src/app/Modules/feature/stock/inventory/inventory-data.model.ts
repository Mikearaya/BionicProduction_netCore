export interface InventoryViewModel {

  itemId: number;
  itemCode: string;
  item: string;
  itemGroupId: number;
  itemGroup: string;
  quantity: number;
  newQuantity: number;
  totalCost: number;
  averageUnitCost: number;
  uom: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
}
