/*
 * @CreateTime: Nov 11, 2018 12:03 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 12:03 AM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CompanyProfileService {
  private url = 'companyprofile';
  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) {
  }

  getCompanyProfile(): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}/${this.url}`);
  }

  createCompanyProfile(profile: any): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/${this.url}`, profile);
  }

  updateCompanyProfile(id: number, profile: any): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${this.url}/${id}`, profile);
  }
}
