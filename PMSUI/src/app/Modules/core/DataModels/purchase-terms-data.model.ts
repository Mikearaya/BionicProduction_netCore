export interface VendorPurchaseTermViewModel {
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


export interface VendorPurchaseTermModel {
  Id: number;
  VendorId: number;
  ItemId: number;
  VendorProductId: string;
  Priority: number | null;
  Leadtime: number | null;
  MinimumQuantity: number | null;
  UnitPrice: number;

}
