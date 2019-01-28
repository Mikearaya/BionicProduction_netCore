import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuthenticationModel, LogInModel } from './authrization.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthrizationService {


  public userName: string;
  public redirectUrl: string;

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient,
    private router: Router) { }

  login(identity: LogInModel): Observable<AuthenticationModel> {
    return this.httpClient.post<AuthenticationModel>(`${this.apiUrl}/login`, identity);
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string {
    return localStorage.getItem('token');
  }
}
