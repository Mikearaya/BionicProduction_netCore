import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { ClickEventArgs } from '@syncfusion/ej2-navigations';

@Injectable()
export class CustomerService {
  private url = 'customers';
  private httpBody: URLSearchParams;
  constructor(@Inject('BASE_URL') private apiUrl: string, private httpClient: HttpClient) {
    this.httpBody = new URLSearchParams();
  }

  getCustomerById(id: number): Observable<Customer> {
    return this.httpClient.get<Customer>(`${this.apiUrl}/${this.url}/${id}`);
  }


  getAllCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(`${this.apiUrl}/${this.url}`);
  }

  addCustomer(newCustomer: Customer): Observable<Customer> {
    this.httpBody = this.prepareRequestBody(newCustomer);
    return this.httpClient.post<Customer>(`${this.apiUrl}/${this.url}`, this.httpBody.toString());
  }
  updateCustomer(updatedCustomer: Customer): Observable<Customer> {
    this.httpBody = this.prepareRequestBody(updatedCustomer);
    return this.httpClient.put<Customer>(`${this.apiUrl}/${this.url}/${updatedCustomer.CUSTOMER_ID}`, this.httpBody.toString());
  }


  private prepareRequestBody(customer: Customer): URLSearchParams {
    const dataModel = new URLSearchParams();
    for (const key in customer) {
      if (customer.hasOwnProperty(key)) {
        const value = customer[key];
        dataModel.set(key, value);
      }
    }
    return dataModel;
  }
}

export class Customer {
  CUSTOMER_ID?: number;
  first_name: string;
  last_name: string;
  driving_licence_id: string;
  passport_number?: string;
  nationality: string;
  country: string;
  city: string;
  hotel_name?: string;
  hotel_phone?: string;
  house_no: string;
  mobile_number: string;
  other_phone: string;
}


