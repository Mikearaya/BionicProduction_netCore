/*
 * @CreateTime: Dec 5, 2018 10:00 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 1:52 PM
 * @Description: Modify Here, Please
 */
export class BomView {
  id: number;
  name: string;
  item: string;
  itemId: number;
  active: boolean;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
  bomItems: BomItemView[];

}


export class BomItemView {
  id: number;
  itemId: number;
  item: string;
  note: string;
  quantity: number;
  uomId: number;
  uom: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}


export class Bom {
  id: number;

  name: string;

  itemId: number;
  active: number | null;
  bomItems: BomItem[] = [];
}


export class BomItem {
  id: number | null;

  itemId: number;
  note: string;

  quantity: number;

  uomId: number;
}
