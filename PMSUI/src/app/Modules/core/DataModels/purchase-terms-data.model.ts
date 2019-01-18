

export interface PurchaseTermViewModel {
  id: number;
  vendorId: number;
  itemId: number;
  vendorProductId: string;
  priority: number | null;
  leadtime: number | null;
  minimumQuantity: number | null;
  unitPrice: number;
  item: string;
  vendor: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
}


export class PurchaseTermModel {
  id: number | null;
  vendorId: number;
  itemId: number;
  vendorProductId: string;
  priority: number | null;
  leadtime: number | null;
  minimumQuantity: number | null;
  unitPrice: number;

}
