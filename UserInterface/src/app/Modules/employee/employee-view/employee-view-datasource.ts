import { EmployeeApiService } from './../employee-api.service';
import { DataSource, CollectionViewer } from '@angular/cdk/collections';
import { catchError, finalize } from 'rxjs/operators';
import { Observable, BehaviorSubject, of } from 'rxjs';


export interface EmployeeViewModel {
  employees: EmployeeView[];
  total: number;
}



export class EmployeeViewDataSource extends DataSource<EmployeeView> {
  private employeeSubject = new BehaviorSubject<EmployeeView[]>([]);
  private countingSubject = new BehaviorSubject<number>(0);
  private loadingSubject = new BehaviorSubject<Boolean>(false);
  public totalEmployees$ = this.countingSubject.asObservable();
  public loading$ = this.loadingSubject.asObservable();
  public data: EmployeeView[];
  constructor(private employeeApiService: EmployeeApiService) {
    super();
  }

  connect(collectionViewer: CollectionViewer): Observable<EmployeeView[]> {
    return this.employeeSubject.asObservable();
  }

  disconnect() {
    this.loadingSubject.complete();
    this.employeeSubject.complete();
    this.countingSubject.complete();
  }

  loadEmployees(filter = '', sortColumn = '', sortOrder = '', pageNumber = 0, pageSize = 5) {
    this.loadingSubject.next(true);
    this.employeeApiService.displayEmployees(filter, sortColumn, sortOrder, pageNumber, pageSize).pipe(
      catchError(() => of([])),
      finalize(() => this.loadingSubject.next(false))
    ).subscribe((data: EmployeeViewModel) => {
          this.countingSubject.next(data.total);
          this.data = data.employees;
          this.employeeSubject.next(data.employees);
    });
  }
}


export class EmployeeView {
  EMPLOYEE_ID: number;
  first_name: String;
  last_name: String;
  country: String;
  city: String;
  sub_city: String;
  wereda: String;
  house_number: String;
  phone_number: String;
  registered_on: String;
}
