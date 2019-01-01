export class WriteOffListModel {
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
  WriteOffItems: WriteOffListModel[];

}


export class NewWriteOffModel {
  itemId: number;

  status: string;

  note: string;

  type: string;

  writeOffBatchs: WriteOffItemModel[] = [];
}



export class WriteOffItemModel {
  batchStorageId: number;
  writeOffId: number;
  quantity: number;
}


export interface UpdatedWriteOffModel {
  id: number;
  status: string;
  note: string;
  type: string;
}
