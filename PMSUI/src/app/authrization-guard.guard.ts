import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthrizationService } from './Modules/authorization/authrization.service';

@Injectable()
export class AuthrizationGuardGuard implements CanActivate {

  constructor(private router: Router,
    private authrizationService: AuthrizationService) {

  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {


    const url: string = state.url;

    return this.checkLogin(url);

  }

  checkLogin(url: string): boolean {

    if (this.authrizationService.isLoggedIn()) { return true; }
    this.authrizationService.redirectUrl = url;
    this.router.navigate(['/login']);
    return false;
  }
}
