export interface ProductGroupView {

  id: number;
  groupName: string;
  description: string;
  parentGroupId: number | null;
  parentGroup: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}


export class ProductGroup {
  id: number | null;
  GroupName: string;
  Description: string;
  ParentGroup: number | null;

}
