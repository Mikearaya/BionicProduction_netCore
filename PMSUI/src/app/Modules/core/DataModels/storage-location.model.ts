/*
 * @CreateTime: Dec 15, 2018 9:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 9:39 PM
 * @Description: Modify Here, Please
 */
export class StorageLocationView {
  id: number;
  name: string;
  note: string;
  active: boolean;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
}

export class StorageLocation {
  id: number;
  name: string;
  note: string;
  active: number | null;
}
