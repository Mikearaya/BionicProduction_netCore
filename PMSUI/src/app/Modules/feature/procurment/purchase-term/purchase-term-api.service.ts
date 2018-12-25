import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { VendorPurchaseTermViewModel, VendorPurchaseTermModel } from 'src/app/Modules/core/DataModels/purchase-terms-data.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PurchaseTermApiService {

  private controller = 'procurments/purchaseterms';
  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private apiUrl: string) {

  }

  getAllPurchaseTerms(id: number): Observable<VendorPurchaseTermViewModel[]> {
    return this.httpClient.get<VendorPurchaseTermViewModel[]>(`${this.apiUrl}`);
  }

  updatePurchaseTerm(id: number, updatedPurchaseTerm: VendorPurchaseTermModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${id}`, updatedPurchaseTerm);
  }

  deletePurchaseTerm(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${id}`);
  }

}
