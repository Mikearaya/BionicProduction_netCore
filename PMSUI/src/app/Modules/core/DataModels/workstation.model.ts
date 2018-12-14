export class WorkstationGroup {
  id?: number;
  name: string;
  description: string;
  active: number | null;

}

export class Workstation {
  id?: number;
  Title: string;
  hourlyRate: number | null;
  workingHours: number | null;
  holidayHours: number | null;
  color: string;
  isActive: number | null;
  maintenanceHours: number | null;
  productivity: number | null;
  groupId: number;
  maintenanceItems: number | null;

}



export class WorkstationGroupView {
  id: string;
  name: string;
  description: string;
  active: boolean;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

}

export class WorkstationView {

  id: number;
  title: string;
  hourlyRate: number | null;
  workingHours: number | null;
  holidayHours: number | null;
  isActive: boolean;
  groupName: string;
  groupId: number;
  maintenanceHours: number | null;
  maintenanceItems: number | null;
  productivity: number | null;
  color: string;
  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;
}

export class WorkstationGroupDetailView {
  id: number;
  name: string;
  description: string;
  active: boolean;

  dateAdded: Date | string | null;
  dateUpdated: Date | string | null;

  workstations: WorkstationView[] = [];
}

