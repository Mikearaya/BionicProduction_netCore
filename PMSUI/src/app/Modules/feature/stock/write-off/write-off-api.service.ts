import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WriteOffListModel, WriteOffDetailModel, NewWriteOffModel, UpdatedWriteOffModel } from './write-off-data.model';
import { Observable } from 'rxjs';

@Injectable()
export class WriteOffApiService {

  private controller = 'inventory/write-offs';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }


  getAllWriteOffs(): Observable<WriteOffListModel[]> {
    return this.httpClient.get<WriteOffListModel[]>(`${this.apiUrl}/${this.controller}`);
  }


  getWriteOffById(id: number): Observable<WriteOffDetailModel> {
    return this.httpClient.get<WriteOffDetailModel>(`${this.apiUrl}/${this.controller}/${id}`);
  }

  getItemkWriteOffById(itemId: number): Observable<WriteOffListModel[]> {
    return this.httpClient.get<WriteOffListModel[]>(`${this.apiUrl}/${this.controller}/item/${itemId}`);
  }

  createWriteOff(newWriteOff: NewWriteOffModel): Observable<WriteOffDetailModel> {
    return this.httpClient.post<WriteOffDetailModel>(`${this.apiUrl}/${this.controller}`, newWriteOff);
  }

  updateWriteOff(updatedWriteOff: UpdatedWriteOffModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${updatedWriteOff.id}`, updatedWriteOff);
  }

  deleteWriteOff(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${id}`);
  }



}
