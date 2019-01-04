export class WriteOffItemDetailModel {
  id: number;
  batchStorageId: number;
  batchId: number;
  storage: string;
  storageId: number;
  item: string;
  batchStatus: string;
  totalBooked: number;
  itemId: number;
  writeOffId: number;

  totalCost: number;
  unitCost: number;
  quantity: number;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
}



export class WriteOffDetailModel {

  id: number;
  itemId: number;
  itemGroupId: number;
  item: string;
  itemGroup: string;
  status: string;
  note: string;
  type: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
  WriteOffItems: WriteOffItemDetailModel[];

}


export class NewWriteOffModel {
  itemId: number;

  note: string;

  type: string;

  writeOffBatchs: WriteOffItemModel[] = [];
}



export class WriteOffItemModel {
  batchStorageId: number;
  writeOffId?: number;
  quantity: number;
}


export interface UpdatedWriteOffModel {
  id: number;
  status: string;
  note: string;
  type: string;
}


export class WriteOffListModel {
  id: number;
  itemId: number;
  itemGroupId: number;
  item: string;
  uom: string;
  itemGroup: string;
  status: string;
  quantity: number;

  totalCost: number;
  note: string;
  type: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}
