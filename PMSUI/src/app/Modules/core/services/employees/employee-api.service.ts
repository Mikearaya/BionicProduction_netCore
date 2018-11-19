/*
 * @CreateTime: Nov 10, 2018 11:55 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 12:24 AM
 * @Description: Modify Here, Please
 */
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class EmployeeApiService {
  private url = 'employees';
  private httpBody: URLSearchParams;

  constructor(
    @Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) {
    this.httpBody = new URLSearchParams();
  }

  getEmployeeById(id: number): Observable<Employee> {
    return this.httpClient.get<Employee>(`${this.apiUrl}/${this.url}/${id}`);
  }

  getAllEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(`${this.apiUrl}/${this.url}`);
  }

  addEmployee(newEmployee: Employee): Observable<Employee> {
    this.httpBody = this.prepareRequestBody(newEmployee);
    return this.httpClient.post<Employee>(`${this.apiUrl}/${this.url}/add`, this.httpBody.toString());
  }

  updateEmployee(updateEmployee: Employee): Observable<Employee> {
    this.httpBody = this.prepareRequestBody(updateEmployee);
    return this.httpClient.post<Employee>(`${this.apiUrl}/${this.url}/update/${updateEmployee.EMPLOYEE_ID}`, this.httpBody.toString());
  }

  deleteEmployee(employeeId: number[]): Observable<Boolean> {
    employeeId.forEach((id) => this.httpBody.append('id[]', `${id}`));
    return this.httpClient.post<Boolean>(`${this.apiUrl}/${this.url}/delete`, this.httpBody.toString());
  }


  private prepareRequestBody(employee: Employee): URLSearchParams {
    const requestBody = new URLSearchParams();

    for (const key in employee) {
      if (employee.hasOwnProperty(key)) {
        const value = employee[key];
        requestBody.set(`${key}`, value);
      }
    }
    return requestBody;

  }
}


export class Employee {
  EMPLOYEE_ID?: number;
  first_name: string;
  last_name: string;
  city: string;
  sub_city: string;
  wereda: string;
  house_number: string;
  role?: string;
  phone_number: string;
  country: string;
}
