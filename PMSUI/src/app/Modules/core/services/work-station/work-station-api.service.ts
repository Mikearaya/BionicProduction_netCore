/*
 * @CreateTime: Dec 14, 2018 9:23 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 14, 2018 11:02 PM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import {
  WorkstationGroupView,
  WorkstationGroupDetailView,
  WorkstationView,
  WorkstationGroup,
  Workstation
} from '../../DataModels/workstation.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class WorkStationApiService {

  private controller = 'productions/workstations';

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) { }

  getWorkStationGroups(): Observable<WorkstationGroupView[]> {
    return this.httpClient.get<WorkstationGroupView[]>(`${this.apiUrl}/${this.controller}`);
  }

  getWorkStations(): Observable<WorkstationView[]> {
    return this.httpClient.get<WorkstationView[]>(`${this.apiUrl}/${this.controller}/stations`);
  }

  getWorkStationById(workstationId: number): Observable<WorkstationView> {
    return this.httpClient.get<WorkstationView>(`${this.apiUrl}/${this.controller}/stations/${workstationId}`);
  }

  getWorkStationGroupById(workstationGroupId: number): Observable<WorkstationGroupView> {
    return this.httpClient.get<WorkstationGroupView>(`${this.apiUrl}/${this.controller}/${workstationGroupId}?type=basic`);
  }

  getWorkStationGroupDetail(workstationGroupId: number): Observable<WorkstationGroupDetailView> {
    return this.httpClient.get<WorkstationGroupDetailView>(`${this.apiUrl}/${this.controller}/${workstationGroupId}?type=detail`);
  }

  createWorkstationGroup(workstationGroup: WorkstationGroup): Observable<Boolean> {
    return this.httpClient.post<Boolean>(`${this.apiUrl}/${this.controller}`, workstationGroup);
  }

  updateWorkstationGroup(workstationGroup: WorkstationGroup): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${workstationGroup.id}`, workstationGroup);
  }

  deleteWorkstationGroup(workstationGroupId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/${workstationGroupId}`);
  }

  createWorkstation(workstation: Workstation): Observable<Boolean> {
    return this.httpClient.post<Boolean>(`${this.apiUrl}/${this.controller}/${workstation.groupId}/stations`, workstation);
  }

  updateWorkstation(workstation: Workstation): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${workstation.groupId}/stations/${workstation.id}`, workstation);
  }


  deleteWorkstation(workstationId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/stations/${workstationId}`);
  }


}
