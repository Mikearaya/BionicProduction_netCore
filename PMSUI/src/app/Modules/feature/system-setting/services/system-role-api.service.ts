import { Injectable, Inject } from '@angular/core';
import { RoleDetailViewModel, RoleListViewModel, SystemRoleModel, SystemFunctionsModel } from '../system-role/system-role-data.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SystemRoleApiService {
  private controller = 'settings/roles';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }


  getSystemRoleById(roleId: string): Observable<RoleDetailViewModel> {
    return this.httpClient.get<RoleDetailViewModel>(`${this.apiUrl}/${this.controller}/${roleId}`);
  }

  getAllSystemRoles(): Observable<RoleListViewModel[]> {
    return this.httpClient.get<RoleListViewModel[]>(`${this.apiUrl}/${this.controller}`);
  }


  getAllSystemFunctions(): Observable<SystemFunctionsModel[]> {
    return this.httpClient.get<SystemFunctionsModel[]>(`${this.apiUrl}/${this.controller}/list`);
  }

  createSystemRole(newRole: SystemRoleModel): Observable<RoleDetailViewModel> {
    return this.httpClient.post<RoleDetailViewModel>(`${this.apiUrl}/${this.controller}`, newRole);
  }


  updateSystemRole(updatedRole: SystemRoleModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${updatedRole.id}`, updatedRole);
  }

  deleteSystemRole(roleId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${roleId}`);
  }

}
