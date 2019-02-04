import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { AuthenticationModel, LogInModel } from './authrization.model';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';

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
    return this.httpClient.post<AuthenticationModel>(`${this.apiUrl}/login`, identity).pipe(
      tap(event => {
          localStorage.setItem('userId', event.userId);
          localStorage.setItem('token', event.token);
          localStorage.setItem('userName', event.userName);
          localStorage.setItem('role', event.role);

      })
    );
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
  getUserName(): string {
    return localStorage.getItem('userName');
  }
  getUserId(): string {
    return localStorage.getItem('userId');
  }

  getUserRole(): string {
    return localStorage.getItem('role');
  }
}
