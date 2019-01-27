export class RoleDetailViewModel {
  id: string;
  name: string;
  access: string;
}

export class SystemRoleModel {
  id?: string;
  name: string;
  access: string;
}

export class RoleListViewModel {
  id: string;
  name: string;
}


export class SystemFunctionsModel {
  Id: string;
  Name: string;
  DisplayName: string;
  AreaName: string;
  Actions: SystemActionsModel[] = [];
  selected: boolean;
  Checked: boolean;
}

export class SystemActionsModel {
  id: string;
  name: string;
  displayName: string;
  controllerId: string;
  selected: boolean;
  type: string;
}
