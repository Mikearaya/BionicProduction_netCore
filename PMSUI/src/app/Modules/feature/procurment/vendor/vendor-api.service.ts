import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VendorViewModel, VendorModel } from 'src/app/Modules/core/DataModels/vendor-data.model';
import { Observable } from 'rxjs';
import { PurchaseTermViewModel} from 'src/app/Modules/core/DataModels/purchase-terms-data.model';

@Injectable({
  providedIn: 'root'
})
export class VendorApiService {

  private controller = 'procurments/vendors';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }


  getAllVendors(): Observable<VendorViewModel[]> {
    return this.httpClient.get<VendorViewModel[]>(`${this.apiUrl}/${this.controller}`);
  }


  getVendorById(id: number): Observable<VendorViewModel> {
    return this.httpClient.get<VendorViewModel>(`${this.apiUrl}/${this.controller}/${id}`);
  }

  getVendorPurchseTerms(id: number): Observable<PurchaseTermViewModel[]> {
    return this.httpClient.get<PurchaseTermViewModel[]>(`${this.apiUrl}/${this.controller}/${id}/purchaseterms`);
  }

  getVendorItemPurchseTerms(id: number, itemId: number): Observable<PurchaseTermViewModel[]> {
    return this.httpClient.get<PurchaseTermViewModel[]>(`${this.apiUrl}/${this.controller}/${id}/items/${itemId}/purchaseterms`);
  }


  createVendor(newVendor: VendorModel): Observable<VendorViewModel> {
    return this.httpClient.post<VendorViewModel>(`${this.apiUrl}/${this.controller}`, newVendor);
  }

  updateVendor(updatedVendor: VendorModel): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${updatedVendor.id}`, updatedVendor);
  }


  deleteVendor(id: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/${id}`);
  }

}
