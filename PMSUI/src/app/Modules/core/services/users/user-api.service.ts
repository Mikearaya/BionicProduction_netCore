import { Injectable, Inject } from '@angular/core';
import { UserViewModel, UserModel, PasswordChangeModel, UpdatedUserModel } from '../../DataModels/user.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserApiService {
  private controller = 'users';

  constructor(@Inject('BASE_URL') private apiUrl: string,
    private httpClient: HttpClient) { }


  getUserById(userId: string): Observable<UserViewModel> {
    return this.httpClient.get<UserViewModel>(`${this.apiUrl}/${this.controller}/${userId}`);
  }

  getAllUsers(): Observable<UserViewModel[]> {
    return this.httpClient.get<UserViewModel[]>(`${this.apiUrl}/${this.controller}`);
  }

  createUser(newUser: UserModel): Observable<UserViewModel> {
    return this.httpClient.post<UserViewModel>(`${this.apiUrl}/${this.controller}`, newUser);
  }

  updateUser(updatedUser: UpdatedUserModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${updatedUser.id}`, updatedUser);
  }

  deleteUser(userId: string): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${this.controller}/${userId}`);
  }

  updateUserPassword(user: PasswordChangeModel): Observable<void> {
    return this.httpClient.put<void>(`${this.apiUrl}/${this.controller}/${user.id}/password`, user);
  }

}
