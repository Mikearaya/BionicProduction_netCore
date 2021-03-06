/*
 * @CreateTime: Nov 10, 2018 11:53 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 8:29 PM
 * @Description: Modify Here, Please
 */
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Customer } from '../../DataModels/customer-data.model';


@Injectable()
export class CustomerService {
  private url = 'customers';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) {

  }

  getCustomerById(id: number): Observable<Customer> {
    return this.httpClient.get<Customer>(`${this.apiUrl}/${this.url}/${id}`);
  }

  getAllCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(`${this.apiUrl}/${this.url}`);
  }

  addCustomer(newCustomer: Customer): Observable<Customer> {
    return this.httpClient.post<Customer>(`${this.apiUrl}/${this.url}`, newCustomer);
  }
  updateCustomer(updatedCustomer: Customer): Observable<Boolean> {
    return this.httpClient.put<Boolean>(`${this.apiUrl}/${this.url}/${updatedCustomer.id}`, updatedCustomer);
  }

  deleteCustomer(customerId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${customerId}`);
  }

  deleteCustomerAddress(customerId: number, addressId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${customerId}/address/${addressId}`);
  }

  deleteCustomerPhone(customerId: number, phoneId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${customerId}/phonenumber/${phoneId}`);
  }

  deleteCustomerSocialMediaAddress(customerId: number, socialId: number): Observable<Boolean> {
    return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${customerId}/socialmedia/${socialId}`);
  }


}

