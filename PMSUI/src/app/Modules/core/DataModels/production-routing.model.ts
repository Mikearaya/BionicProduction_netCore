export class RoutingModel {
  id?: number;
  itemId: number;
  name: string;
  note: string;
  fixedCost: number | null;
  variableCost: number | null;
  quantity: number | null;
  Operations: RoutingOperationModel[] = [];
  Boms: RoutingBomsModel[] = [];
}


export class RoutingOperationModel {
  id?: number;
  routingId?: number;
  workstationId: number;
  operation: string;
  fixedCost: number | null;
  variableCost: number | null;
  fixedTime: number | null;
  variableTime: number | null;
  quantity: number;
}

export class RoutingBomsModel {
  id: number | null;
  routingId: number;
  bomId: number;
}


export class RoutingViewModel {
  id: number;
  name: string;
  itemId: number;
  itemName: string;
  itemGroupId: number;
  itemGroupName: string;
  approximateCost: number | null;
  approximateTime: number | null;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
}


export class RoutingOperationViewModel {
  id: number;
  routingId: number;
  routing: string;
  workstationId: number;
  workstation: string;
  operation: string;
  fixedCost: number | null;
  variableCost: number | null;
  fixedTime: number | null;
  variableTime: number | null;
  quantity: number;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}


export class RoutingBomViewModel {
  id: number;
  routingId: number;
  routing: string;
  bomId: number;
  bom: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}


export class RoutingDetailViewModel {
  id: number;
  name: string;
  itemId: number;
  itemName: string;
  itemGroupId: number;
  itemGroupName: string;
  otherFixedCost: number | null;
  otherVariableCost: number | null;
  quantity: number | null;
  fixedCost: number | null;
  approximateCost: number | null;
  approximateTime: number | null;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
  routingBoms: RoutingBomViewModel[] = [];
  routingOperations: RoutingOperationViewModel[] = [];

}
