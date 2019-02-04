import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthrizationService } from '../Modules/authorization/authrization.service';
import { MenuAnimationSettings, MenuEventArgs } from '@syncfusion/ej2-navigations';
import { ToolbarComponent } from '@syncfusion/ej2-angular-navigations';
import { Router } from '@angular/router';

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.css']
})
export class EntryComponent implements OnInit {
  logOutAlign = 'Right';



  constructor(private authrizationService: AuthrizationService,
    private router: Router) { }

  ngOnInit() {
  }

  isLogedIn(): boolean {
    return this.authrizationService.isLoggedIn();
  }
  logOut(): void {
    this.authrizationService.logout();
  }

  changePassword(): void {
    this.router.navigate([`/settings/users/${this.authrizationService.getUserId()}/password`]);
  }


  updateProfile(): void {
    this.router.navigate([`/settings/users/${this.authrizationService.getUserId()}/update`]);
  }

  private select(args: MenuEventArgs): void {
    console.log(args.item.id);
  }
}
