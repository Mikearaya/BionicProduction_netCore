import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { PurchaseTermViewModel, PurchaseTermModel } from 'src/app/Modules/core/DataModels/purchase-terms-data.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PurchaseTermApiService {

  private controller = 'procurments/purchaseterms';
  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) {

  }


  getPurchaseTermById(id: number): Observable<PurchaseTermViewModel> {
    return this.httpClient.get<PurchaseTermViewModel>(`${this.apiUrl}/${this.controller}/${id}`);
  }

  getAllPurchaseTerms(id: number): Observable<PurchaseTermViewModel[]> {
    return this.httpClient.get<PurchaseTermViewModel[]>(`${this.apiUrl}/${this.controller}`);
  }

  createPurchaseTerm(newPurchaseTerm: PurchaseTermModel): Observable<PurchaseTermViewModel> {
    return this.httpClient.post<PurchaseTermViewModel>(`${this.apiUrl}/${this.controller}`, newPurchaseTerm);
  }

  getVendorPurchseTerms(id: number): Observable<PurchaseTermViewModel[]> {
    return this.httpClient.get<PurchaseTermViewModel[]>(`${this.apiUrl}/procurments/vendors/${id}/purchaseterms`);
  }

  updatePurchaseTerm(id: number, updatedPurchaseTerm: PurchaseTermModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${id}`, updatedPurchaseTerm);
  }

  deletePurchaseTerm(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${id}`);
  }

}
