/*
 * @CreateTime: Dec 5, 2018 10:11 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 11:48 PM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BomView, Bom } from 'src/app/Modules/core/DataModels/bom.model';
import { Observable } from 'rxjs';

@Injectable()
export class BomApiService {

  private controller = 'products/boms';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) {
  }


  getAllBomItems(): Observable<BomView[]> {
    return this.httpClient.get<BomView[]>(`${this.apiUrl}/${this.controller}`);
  }


  getBomItemById(bomId: number): Observable<BomView> {
    return this.httpClient.get<BomView>(`${this.apiUrl}/${this.controller}/${bomId}`);
  }

  getItemBOMsById(itemId: number): Observable<BomView[]> {
    return this.httpClient.get<BomView[]>(`${this.apiUrl}/products/${itemId}/boms`);
  }


  saveBomItem(bom: Bom): Observable<BomView> {
    return this.httpClient.post<BomView>(`${this.apiUrl}/${this.controller}`, bom);
  }


  updateBomItem(updatedBom: Bom): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.controller}/${updatedBom.id}`, updatedBom);
  }

  deleteBomItem(deletedBomId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.controller}/${deletedBomId}`);
  }
}
