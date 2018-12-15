/*
 * @CreateTime: Dec 15, 2018 9:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 9:43 PM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StorageLocationView, StorageLocation } from '../../DataModels/storage-location.model';
import { Observable } from 'rxjs';

@Injectable()
export class StorageLocationApiService {

  private controller = 'storages';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }

  getAllStorageLocations(): Observable<StorageLocationView[]> {
    return this.httpClient.get<StorageLocationView[]>(`${this.apiUrl}/${this.controller}`);
  }

  getStorageLocationById(storageId: number): Observable<StorageLocationView> {
    return this.httpClient.get<StorageLocationView>(`${this.apiUrl}/${this.controller}/${storageId}`);
  }

  createStorageLocation(storage: StorageLocation): Observable<Boolean> {
    return this.httpClient.post<Boolean>(`${this.apiUrl}/${this.controller}`, storage);
  }

  updateStorageLocation(storage: StorageLocation): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${storage.id}`, storage);
  }

  deleteStorageLocation(storageId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/${storageId}`);
  }


}
