import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RoutingViewModel, RoutingDetailViewModel, RoutingModel } from '../../DataModels/production-routing.model';
import { Observable } from 'rxjs';

@Injectable()
export class RoutingApiService {
  private mainController = 'productions';
  private subController = 'routings';
  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }

  getAllProductionRoutings(): Observable<RoutingViewModel[]> {
    return this.httpClient.get<RoutingViewModel[]>(`${this.apiUrl}/${this.mainController}/${this.subController}`);
  }

  getItemRoutings(itemId: number): Observable<RoutingViewModel[]> {
    return this.httpClient.get<RoutingViewModel[]>(`${this.apiUrl}/${this.mainController}/${itemId}/${this.subController}`);
  }

  getProductionRoutingById(id: number): Observable<RoutingDetailViewModel> {
    return this.httpClient.get<RoutingDetailViewModel>(`${this.apiUrl}/${this.mainController}/${this.subController}/${id}`);
  }

  getItemRoutingById(itemId: number, id: number): Observable<RoutingDetailViewModel> {
    return this.httpClient.get<RoutingDetailViewModel>(`${this.apiUrl}/${this.mainController}/${itemId}/${this.subController}/${id}`);
  }

  createRouting(newRouting: RoutingModel): Observable<RoutingDetailViewModel> {
    return this.httpClient
      .post<RoutingDetailViewModel>(`${this.apiUrl}/${this.mainController}/${newRouting.itemId}/${this.subController}`, newRouting);
  }

  updateRouting(updatedRouting: RoutingModel): Observable<Boolean> {
    return this.httpClient
      .put<Boolean>(
        `${this.apiUrl}/${this.mainController}/${updatedRouting.itemId}/${this.subController}/${updatedRouting.id}`, updatedRouting);
  }

  deleteRoutingById(id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.mainController}/${this.subController}/${id}`);
  }

  deleteItemRoutingById(itemId: number, id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.mainController}/${itemId}/${this.subController}/${id}`);
  }
}
